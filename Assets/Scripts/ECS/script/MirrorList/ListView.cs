
using UnityEngine;
using UnityEngine.UI;

public class ListView : ScrollRect
{
      
        
        private ListViewManager ListViewManager;
        
        public ListViewDataProvider _dataProvider;
        
        public Vector2 Padding;
        public Vector2 Margin;
        public int Segment = 1;
        public RectTransform CellPrefab;
        
        public void SetDataProvider(ListViewDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        
        public void OnDataSourceChange()
        {
            ReloadData();
        }
        
    
        
        private void ReloadData()
        {
            if (_dataProvider == null)
            {
                if (Application.isPlaying)
                {
                    Debug.LogWarning("ListView:DataProvider is null !");
                }

                return;
            }

            StopMovement();
            vertical = false;
            horizontal = true;
            if (ListViewManager == null)
            {
                ListViewManager = new ListViewManager();
            }


            ListViewManager.OnMeasure(this);
            onValueChanged.RemoveListener(_OnValueChanged);
            ListViewManager.DoStart();
            onValueChanged.AddListener(_OnValueChanged);
        }

        private void _OnValueChanged(Vector2 normalizedPos)
        {
            ListViewManager.OnValueChanged();
        }

}
