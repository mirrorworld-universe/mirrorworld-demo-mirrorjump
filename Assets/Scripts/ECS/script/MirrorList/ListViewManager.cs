using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Task {
    public int Index;
}
    
    
public class ViewRectCell
{

    public Transform Item;
    public int Index;
   
}
public class ListViewManager : MonoBehaviour
{
   
        private ListView _listView;
        private RectTransform _cellPrefab =>_listView.CellPrefab;
        
        private RectTransform _viewport => _listView.viewport;
        
        private RectTransform _content => _listView.content;
        
        private ListViewDataProvider _dataProvider => _listView._dataProvider;

    
        private int _numOfRowOrCol;
        private int _totalRowOrColCount = 0;
        private float _cellWidth;
        private float _cellHeight;
        
        
        // delay load Queue
        private Queue<Task> _allLoadingTasks = new Queue<Task>();
        
        // object pool
        private Stack<GameObject> _itemPool = new Stack<GameObject>();
        
        private HashSet<int> _allCellIds = new HashSet<int>();
        
        private Dictionary<int, ViewRectCell> _idToCells = new Dictionary<int, ViewRectCell>();
        
        private List<ViewRectCell> _allCells = new List<ViewRectCell>();
        
        
        // bound 
        private int _minIndex = 0;
        private int _maxIndex => Mathf.Min(_minIndex + _totalVisibleCellCount, _dataProvider.GetCellCount()) - 1;
        private int _totalVisibleCellCount => _totalRowOrColCount * _numOfRowOrCol;  
        
        
        // Asynchronous lazy loading Task
        private Coroutine _asyTask;
        
        public int MaxCellCreateCountPerFrame = 4;
        
        
        // this method will do some Measure to calculate
        public void OnMeasure(ListView mirrorList)
        {
            this._listView = mirrorList;
            
              
            _numOfRowOrCol = _isGrid ? mirrorList.Segment : 1;
            
            // calculate cell practical size
            _cellWidth = _cellPrefab.sizeDelta.x + mirrorList.Margin.x;
            _cellHeight = _cellPrefab.sizeDelta.y + mirrorList.Margin.y;
            
            // visibility area max row or col count
            _totalRowOrColCount =
                (_isVertical
                    ? Mathf.CeilToInt(_viewport.rect.height / _cellHeight)
                    : Mathf.CeilToInt(_viewport.rect.width / _cellWidth))+1;
            
            
            // set the anchor of template
            _cellPrefab.gameObject.SetActive(true);
            SetTopLeftAnchor(_cellPrefab);
            _cellPrefab.gameObject.SetActive(false);
            
            ClearData();
        }
        
        
        public void DoStart() {
            
           SetTopLeftAnchor(_content);
            
            OnReMeasure();
            
            
            var rawSize = _content.rect.size;
            int numOfRows = Mathf.CeilToInt(_dataProvider.GetCellCount() / _numOfRowOrCol) + 1;
            var sizeDelta = (_isVertical
                ? new Vector2(rawSize.x, numOfRows * _cellHeight)
                : new Vector2(numOfRows * _cellWidth, rawSize.y));
            sizeDelta += _listView.Padding;
            _content.sizeDelta = sizeDelta;
            
            ClearData();
            CheckVisibility();
            
            
            _asyTask = _listView.StartCoroutine(UpdateTasks());
            
            
        }
        private void ClearData()
        {
            
            
            DestroyCells();
            if (_asyTask != null) {
                _listView.StopCoroutine(_asyTask);
                _asyTask = null;
            }
            
            

            _allLoadingTasks.Clear();
            _allCellIds.Clear();
            _idToCells.Clear();
            _allCells.Clear();
            
        }
        public void DestroyCells(bool isClearPool= false)
        {
             _allLoadingTasks.Clear();
             _allCellIds.Clear();

             foreach (var cell in _allCells)
             {
                 CellCaching(cell);
             }
             
             _allCells.Clear();

             if (isClearPool)
             {
                 var count = _itemPool.Count;
                 while (count > 0)
                 {
                     var item = _itemPool.Pop();

                     if (null != item)
                     {
                         GameObject.Destroy(item);
                     }
                     count--;
                 }
                 _itemPool.Clear();
             }
             else
             {
                 // Auto shrink pool size
                 int maxCount = _totalRowOrColCount * _numOfRowOrCol;
                 var needDeleteCacheCount = _itemPool.Count - maxCount;
                 for (int i = 0; i < needDeleteCacheCount; i++) {
                     var item = _itemPool.Pop();
                     if (item != null) {
                         GameObject.Destroy(item);
                     }
                 }
                 
                 
             }
             
             
             
        }
        
        private void CellCaching(ViewRectCell cell)
        {
            var gone = cell.Item.gameObject;
            if (gone == null) return;
            gone.SetActive(false);
            _itemPool.Push(gone);
        }
        
        private void AddTask(int index) {
            _allLoadingTasks.Enqueue(new Task() {Index = index});
        }
        
        // the method will loading Task
        private IEnumerator UpdateTasks() {
            while (true) {
                for (int i = 0; i < MaxCellCreateCountPerFrame;) {
                    
                    if (_allLoadingTasks.Count == 0) {
                        break;
                    }
                    var task = _allLoadingTasks.Dequeue();
                    
                    if (IsInRange(task.Index) && !_allCellIds.Contains(task.Index)) {
                        var item = GetOrCreateCell();
                        item.anchoredPosition = GetAnchorPos(task.Index);
                        _allCells.Add(new ViewRectCell() {Item = item, Index = task.Index});
                        _allCellIds.Add(task.Index);
                        _dataProvider.SetCellData(item.gameObject, task.Index);
                        i++;
                    }
                }
                
                
                yield return null;
            }
        }
        
        private bool IsInRange(int index) {
            return index >= _minIndex && index <= _maxIndex;
        }
        
        RectTransform GetOrCreateCell() {
            
            // if has cached  item
            if (_itemPool.Count > 0) {
                var item = _itemPool.Pop();
                if (item != null) {
                    item.gameObject.SetActive(true);
                    return item.transform as RectTransform;
                }
            }
           
            var tran = (UnityEngine.Object.Instantiate(_cellPrefab.gameObject)).GetComponent<RectTransform>();
            tran.gameObject.SetActive(true);
            tran.SetParent(_content, false);
            return tran;
        }
        
        private Vector2 GetAnchorPos(int index) {
            
            
            var row = index / _numOfRowOrCol;
            var col = index % _numOfRowOrCol;
            if (!_isVertical) {
                row = index % _numOfRowOrCol;
                col = index / _numOfRowOrCol;
            }
     
            return new Vector2(col * _cellWidth, -row * _cellHeight) +
                   new Vector2(_listView.Padding.x, -_listView.Padding.y);
        }
        
        
        // Update bound info,when OnChangeValue is happen the anchor position of content will change need to remeasure and update visibility area 
        private void OnReMeasure() {
            
            // onReMeasure
            _cellWidth = _cellPrefab.sizeDelta.x + _listView.Margin.x;
            _cellHeight = _cellPrefab.sizeDelta.y + _listView.Margin.y;
            
            _totalRowOrColCount = (_isVertical
                ? Mathf.CeilToInt(_viewport.rect.height / _cellHeight)
                : Mathf.CeilToInt(_viewport.rect.width / _cellWidth)) + 1;
            
            // The minimum index is inferred from the current anchor
            var curContentAnchor = _content.anchoredPosition;
            var count = (_isVertical
                ? Mathf.CeilToInt(curContentAnchor.y / _cellHeight)
                : Mathf.CeilToInt(-curContentAnchor.x / _cellWidth));
            _minIndex = Mathf.Max(0, count - 1) * _numOfRowOrCol;
           
        }
        
        // Checking Visibility
        private void CheckVisibility() {
            _idToCells.Clear();
            
            
            // all visibility cell before OnValueChange Callback
            foreach (var cell in _allCells) {
                _idToCells[cell.Index] = cell;
            }
            _allCells.Clear();


            for (int i = _minIndex; i <= _maxIndex; i++) {
                if (!_idToCells.ContainsKey(i)) {
                    AddTask(i);
                }
                else {
                    _allCells.Add(_idToCells[i]);
                }
                
                _idToCells.Remove(i);
            }

         
            // the rest of item will be caching
            foreach (var pair in _idToCells) {
                var cell = pair.Value;
                _allCellIds.Remove(pair.Key);
                CellCaching(cell);
               
            }
        }
        
        // when OnValueChange Event is trigger should ReMeasure first and then check Visible
        public void OnValueChanged()
        {
            OnReMeasure();
            CheckVisibility();
        }
        
        
        private void SetTopLeftAnchor(RectTransform rectTransform) {
            SetAnchor(rectTransform, new Vector2(0, 1));
        }
        
        private void SetAnchor(RectTransform rectTransform, Vector2 pos) {
            float width = rectTransform.rect.width;
            float height = rectTransform.rect.height;
            rectTransform.anchorMin = pos;
            rectTransform.anchorMax = pos;
            rectTransform.pivot = pos;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = new Vector2(width, height);
        }
        
        
        
}
