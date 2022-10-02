using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NftTrade : MonoBehaviour
{

    private NFTCellData CurrentNftCellData;
     
    // sell
    public GameObject SellRoot;

    public Image SellHeader;

    public TextMeshProUGUI SellReceiveTips;

    public TextMeshProUGUI SellNFTID;

    public void OpenSell(NFTCellData nftCellData)
    {

        CurrentNftCellData = nftCellData;
        SellRoot.SetActive(true);
        SellDataParse();
        
    }

    private void SellDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {   
            SetImage(CurrentNftCellData.DataParsingEntity.image,SellHeader);
            if (null != CurrentNftCellData.DataParsingEntity.name)
            {
                SellNFTID.text = CurrentNftCellData.DataParsingEntity.name;
            }
        }
        
    }
    
    
    public void CloseSell()
    {
        SellRoot.SetActive(false);
        
    }

    
    // todo SDK Call ListNFT
    public void SellConfirm()
    {
        
        CloseSell();
        
    }
    
    
    
    
    //manage list
    public GameObject ManageRoot;

    public Image ManageHeader;

    public TextMeshProUGUI ManageReceiveTips;
    
    public TextMeshProUGUI CurrentPrice;

    public TextMeshProUGUI ManageNFTID;

    public GameObject CancelDialog;

    public GameObject UpdateDialog;
    
    
    public void OpenManageList(NFTCellData nftCellData)
    {

        CurrentNftCellData = nftCellData;
        ManageRoot.SetActive(true);
     
        ManageDataParse();
    }

    private void ManageDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {  
            SetImage(CurrentNftCellData.DataParsingEntity.image,ManageHeader);
            
            if (null != CurrentNftCellData.DataParsingEntity.name)
            {
               ManageNFTID.text = CurrentNftCellData.DataParsingEntity.name;
            }
            
            //price
            
            // if (null != CurrentNftCellData.DataParsingEntity.)
            // {
            //     ManageNFTID.text = CurrentNftCellData.DataParsingEntity.ID;
            // }
            
        }
        
        
    }
    
    public void CloseManageList()
    {
        ManageRoot.SetActive(false);
    }


    public void OpenCancelDialog()
    {   
        ManageRoot.SetActive(false);
        CancelDialog.SetActive(true);
    }

    public void OpenUpdateDialog()
    {
        ManageRoot.SetActive(false);
      UpdateDialog.SetActive(true);
    }

    public void CloseCancelDialog()
    {
        CancelDialog.SetActive(false);
    }

    public void CloseUpdateDialog()
    {
        UpdateDialog.SetActive(false);
    }
    
    
    
    // todo SDK Call  Cancel List
    public void CancelList()
    {
        // call SDK
        if (null != CurrentNftCellData)
        {
            
        }
        
        Thread.Sleep(1000);
        
        CloseCancelDialog();
        
        
    }
    
    // todo SDK Call  List Update
    public void UpdatePrice()
    {
        if (null != CurrentNftCellData)
        {
            
        }
        
        Thread.Sleep(1000);
        
        CloseUpdateDialog();
        
    }
    
    
    
    
    
    // transfer NFT
    public GameObject TransferRoot;

    public GameObject NFTDetailRoot;
    
    public Image TransferHeader;

    public TextMeshProUGUI NFTID;



    public void OpenTransfer(NFTCellData nftCellData)
    {
        CurrentNftCellData = nftCellData;
        TransferRoot.SetActive(true);
        
        TransferDataParse();
        
    }
    private void TransferDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {  
            SetImage(CurrentNftCellData.DataParsingEntity.image,TransferHeader);
            
            if (null != CurrentNftCellData.DataParsingEntity.name)
            {
                ManageNFTID.text = CurrentNftCellData.DataParsingEntity.name;
            }
        }
    }
    
    
    
    // todo SDK Call  Transfer
    public void ConfirmTransfer()
    {
        //call SDK from CurrentNFTData and input
        Thread.Sleep(1000);
        CloseTransfer();
    }

    public void CloseTransfer()
    {
        TransferRoot.SetActive(false);
    }

    public void BackToDetails()
    {
        TransferRoot.SetActive(false);
        NFTDetailRoot.SetActive(true);
    }
    
    
    // header  Image loader
    private async void SetImage(string url,Image header)
    {
        Sprite sprite = await ImageLoader.LoadSprite(url);
        if (null != sprite)
        {
            if (null != header && transform.gameObject.activeSelf)
            {
                header.sprite = sprite;
            }
        }else
        {
            header.sprite = null;
        }
        
    }


}
