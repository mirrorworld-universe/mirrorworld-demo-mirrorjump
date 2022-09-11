
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ListViewDataProvider : MonoBehaviour
{

        public ListView NFTListView;
        
        private List<NFTCellData> DataSource = new List<NFTCellData>();
        
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
                    if (mirror.ID == ID)
                    {
                        DataSource.Remove(mirror);
                    }
                    
                }
            }
            
            // notify data update
            NFTListView.OnDataSourceChange();
        }
        
      
        private void Awake()
        {   
            // Test Data
            NFTListView.SetDataProvider(this);
            for (int i = 0; i < 30; i++)
            {
                NFTCellData nftDataCell = new NFTCellData();
                nftDataCell.ID = i + "content";
                DataSource.Add(nftDataCell);
            }
            
            NFTListView.OnDataSourceChange();
        }


    
        public void SetCellData(GameObject gameObject, int index)
        {
            var NFTViewCell = gameObject.GetComponent<NFTViewCell>();
            NFTViewCell.OnDataBind(DataSource[index]);
        }

        public int  GetCellCount()
        {
            return DataSource.Count;
        }

}
