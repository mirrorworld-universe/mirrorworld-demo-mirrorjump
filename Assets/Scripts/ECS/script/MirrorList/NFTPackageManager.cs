using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NFTPackageManager : MonoBehaviour
{
    public ListView ListView;

    public CanvasGroup LeftPageTurningCanvas;

    public CanvasGroup RightPageTurningCanvas;

    public GameObject Package;

    public ListViewDataProvider ListViewDataProvider;

    public CallSDK CallSDK;

    public TextMeshProUGUI PageNumber;

    public void OnTurningLeft()
    {
        SoundManager.Instance.PlaySound(SoundName.TurnPage);
        ListView.ToLeftPage();
        PageTurningStateUpdate(false);
    }

    public void OnTurningRight()
    {
        SoundManager.Instance.PlaySound(SoundName.TurnPage);
        ListView.ToRightPage();
        PageTurningStateUpdate(false);
    }

    public void OpenPackage()
    {
    
        SoundManager.Instance.PlaySound(SoundName.Pop);
        CallSDK.FetchNFTS();

    }


    public void RefreshData( List<NFTCellData> datas)
    {

        ListViewDataProvider.NFTListView.SetDataProvider(ListViewDataProvider);
        ListViewDataProvider.DataSource.Clear();
        
        if (null != datas && datas.Count > 0)
        {
            ListViewDataProvider.DataSource.AddRange(datas);
            ListViewDataProvider.NFTListView.OnDataSourceChange();
        }
        PageTurningStateUpdate(true);
        Package.SetActive(true);
        
    }
    
    
    
    
    
    
    


    public void ClosePackage()
    {
        SoundManager.Instance.PlaySound(SoundName.Close);
        Package.SetActive(false);
    }

    public void PageTurningStateUpdate(bool IsFirst)
    {
        PageTurningState State = ListView.GetPageTurningState(IsFirst);

        if (State == PageTurningState.Both)
        {
            LeftPageTurningCanvas.alpha = 1;
            RightPageTurningCanvas.alpha = 1;

            PageNumber.text = ListView.GetCurrentPage().ToString();


        }
        else if (State == PageTurningState.None)
        {
            LeftPageTurningCanvas.alpha = 0;
            RightPageTurningCanvas.alpha = 0;

            PageNumber.text = "";



        }
        else if (State == PageTurningState.OnlyLeft)
        {
            LeftPageTurningCanvas.alpha = 1;
            RightPageTurningCanvas.alpha = 0.5f;

            PageNumber.text = ListView.GetCurrentPage().ToString();

        }
        else if (State == PageTurningState.OnlyRight)
        {
            LeftPageTurningCanvas.alpha = 0.5f;
            RightPageTurningCanvas.alpha = 1;

            PageNumber.text = ListView.GetCurrentPage().ToString();
        }



    }
}
