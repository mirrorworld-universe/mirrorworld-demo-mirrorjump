
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ListViewDataProvider : MonoBehaviour
{

        public ListView NFTListView;
        
        public RectTransform CellPrefab;
        
        public float TopRelativeDistance = 200;
        
        public float LeftRelativeDistance = 200 ;

        public float PageSpace = 420 ;
        
        public List<NFTCellData> DataSource = new List<NFTCellData>();
        

        public bool IsNFTPackage;
        
        public MirrorDetailsManager mirrorDetailsManager;

        public Sprite DefaultSprite;

      
        
        
        
        public void AddMirrors(List<NFTCellData> Mirrors)
        {
            if (null == DataSource)
            {
                DataSource = new List<NFTCellData>();
            }
            
            DataSource.AddRange(Mirrors);
            
            // notify data update
            NFTListView.OnDataSourceChange();
        }


        public void AddSingleMirror(NFTCellData Mirror)
        {
            if (null == DataSource)
            {
                DataSource = new List<NFTCellData>();
            }
            
            DataSource.Add(Mirror);
            
            // notify data update
            NFTListView.OnDataSourceChange();
        }


        public void RemoveSingleMirrorByID(string ID) 
        {
            if (null != DataSource)
            {
                foreach (var mirror in DataSource)
                {
                    if (mirror.DataParsingEntity.ID == ID)
                    {
                        DataSource.Remove(mirror);
                    }
                    
                }
            }
            
            // notify data update
            NFTListView.OnDataSourceChange();
        }
        
      
       
        
        public void SetCellData(GameObject gameObject, int index)
        {
            var NFTViewCell = gameObject.GetComponent<NFTViewCell>();
            NFTViewCell.OnDataBind(DataSource[index],DefaultSprite);
        }

        public int  GetCellCount()
        {
            return DataSource.Count;
        }
        
        
//         
//         // add Event  
//         // 1. tab focus on  2.data refresh
//         item.gameObject.GetComponent<Button>().onClick.AddListener(delegate
//         {
//             OnButtonClicked();
//         });
// item.gameObject.GetComponent<Button>().name = "tab" + i;
//             
// AllTransforms.Add(item);
//             
// }
//         
// }
//
//
// private void OnButtonClicked()
// {
//     var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
//
//     for (int i = 0; i < AllTransforms.Count; i++)
//     {
//         if (AllTransforms[i].GetComponent<Button>().name == button.name)
//         {
//             TabFocusOn(i);
//             DataRefreshNotify(i);
//             CurrentTabChange(i);
//             break;
//         }
//     }
        
      
        


}
