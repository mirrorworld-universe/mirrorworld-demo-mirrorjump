
using System;
using MirrorworldSDK;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class NftTrade : MonoBehaviour
{

    private NFTCellData CurrentNftCellData;
     
    // sell
    public GameObject SellRoot;

    public Image SellHeader;
    

    public TextMeshProUGUI SellNFTID;
    
  
    


    public TMP_InputField SellPrice;

    public TMP_InputField NewPrice;
    
    public TMP_InputField Address;



    public Button SellConfirmButton;

    public Button TransformConfirmButton;
    
    public Button UpdateConfirmButton;

    
    public GameObject SellMask;

    public GameObject TransformMask;
    
    public GameObject UpdateMask;


    public GameObject SellReceive;

    public GameObject NewSellReceive;
    
    

    private float InputSellPrice;

    private float InputUpdatePrice;

    private string InputTransferAddress;
    
    



    private void Update()
    {
        if (SellRoot.activeSelf)
        {
            
            try
            {
                InputSellPrice = float.Parse(SellPrice.text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                SellReceive.SetActive(false);
            }

            if (null != InputSellPrice&&InputSellPrice != 0)
            {
                SellConfirmButton.interactable = true;
                SellMask.SetActive(false);
                SellReceive.SetActive(true);
                SellReceive.GetComponent<TextMeshProUGUI>().text = "you will receive" + " "+ CalculatePrice(InputSellPrice)+ " SOL";

            }
            else
            {
                SellConfirmButton.interactable = false;
                SellMask.SetActive(true);
              
            }
            
        }


        if (ManageRoot.activeSelf)
        {
            try
            {
                InputUpdatePrice = float.Parse(NewPrice.text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                NewSellReceive.SetActive(false);
            }

            if (null != InputUpdatePrice && InputUpdatePrice != 0)
            {
               UpdateConfirmButton.interactable = true;
               UpdateMask.SetActive(false);
               NewSellReceive.SetActive(true);
               NewSellReceive.GetComponent<TextMeshProUGUI>().text = "you will receive" + " " +CalculatePrice(InputUpdatePrice)+ " SOL";
               
            }
            else
            {
                UpdateConfirmButton.interactable = false;
                UpdateMask.SetActive(true);
            }
            
            
        }

        if (TransferRoot.activeSelf)
        {

            InputTransferAddress = Address.text;
        
            if (null != InputTransferAddress && InputTransferAddress!= "" )
            {
                TransformConfirmButton.interactable = true;
                TransformMask.SetActive(false);
            }
            else
            {
                TransformConfirmButton.interactable = false;
                TransformMask.SetActive(true);
                
            }
            
        }
        
        
        
        
    }



    private string CalculatePrice(float price)
    {
        double res = price * 0.9575;
        return res.ToString("f5");
    }

    public void OpenSell(NFTCellData nftCellData)
    {

        CurrentNftCellData = nftCellData;
        SellRoot.SetActive(true);
        SellDataParse();

        SellPrice.text = "";
        SellConfirmButton.interactable = false;
        InputSellPrice = 0f;
        SellReceive.SetActive(false);
        SellReceive.GetComponent<TextMeshProUGUI>().text = "";

    }

    private void SellDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {   
            SetImage(CurrentNftCellData.NftData.image,SellHeader);
            if (null != CurrentNftCellData.NftData.name)
            {
                SellNFTID.text = CurrentNftCellData.NftData.name;
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
        float price = float.Parse(SellPrice.text);
        
        MirrorSDK.ListNFT(CurrentNftCellData.NftData.mintAddress,price,Confirmation.Confirmed,(result) =>
        {
            
        });
        
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
        
        NewPrice.text = "";
        UpdateConfirmButton.interactable = false;
        InputUpdatePrice = 0f;
        NewSellReceive.SetActive(false);
        NewSellReceive.GetComponent<TextMeshProUGUI>().text = "";

    }

    private void ManageDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {  
            SetImage(CurrentNftCellData.NftData.image,ManageHeader);
            
            if (null != CurrentNftCellData.NftData.name)
            {
               ManageNFTID.text = CurrentNftCellData.NftData.name;
            }
            
       
            
             if (null != CurrentNftCellData.NftData)
             {
                 CurrentPrice.text = CurrentNftCellData.NftData.listings[CurrentNftCellData.NftData.listings.Count - 1]
                     .price.ToString();
             }
            
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
            MirrorSDK.CancelNFTListing(CurrentNftCellData.NftData.mintAddress,CurrentNftCellData.NftData.listings[CurrentNftCellData.NftData.listings.Count-1].price,Confirmation.Confirmed,(result) =>
            {
              
            });
        }
        
       
        
        CloseCancelDialog();
        
        
    }
    
    // todo SDK Call  List Update
    public void UpdatePrice()
    {
        if (null != CurrentNftCellData)
        {
            
            float price = float.Parse(NewPrice.text);
        
            MirrorSDK.UpdateNFTListing(CurrentNftCellData.NftData.mintAddress,price,Confirmation.Confirmed,(result) =>
            {
                
            
            });
            
            
        }
        
      
        
        CloseUpdateDialog();
        
    }
    
    
    
    
    
    // transfer NFT
    public GameObject TransferRoot;

    public GameObject NFTDetailRoot;
    
    public Image TransferHeader;

    public TextMeshProUGUI TransferNFTID;



    public void OpenTransfer(NFTCellData nftCellData)
    {
        CurrentNftCellData = nftCellData;
        TransferRoot.SetActive(true);
        
        TransferDataParse();
        Address.text = "";
        TransformConfirmButton.interactable = false;
        InputTransferAddress = null;

    }
    private void TransferDataParse()
    {
        if (null == CurrentNftCellData)
        {
            return;
        }
        else
        {  
            SetImage(CurrentNftCellData.NftData.image,TransferHeader);
            
            if (null != CurrentNftCellData.NftData.name)
            {
               TransferNFTID.text = CurrentNftCellData.NftData.name;
            }
        }
    }
    
    
    
    // todo SDK Call  Transfer
    public void ConfirmTransfer()
    {
        string address = Address.text.ToString();
        
        MirrorSDK.TransferNFT(CurrentNftCellData.NftData.mintAddress,address,(result) =>
        {
            
        });
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
