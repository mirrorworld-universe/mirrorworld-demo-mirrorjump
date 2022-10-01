
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NFTDetailsManager : MonoBehaviour
{
    
    // nft package
    public Image nftHeader;

    public TextMeshProUGUI nftID;

    public TextMeshProUGUI nftContent;

    public TextMeshProUGUI nftRarity;

    private NFTCellData CurrentMirror;
    
    public GameObject NFTDetails;

    public NFTPackageManager NFTPackageManager;
    
    public CallSDK CallSDK;
  
    public void OpenNFTPackageDetails(NFTCellData nftCellData)
    {
        SoundManager.Instance.PlaySound(SoundName.Pop);
        NFTPackageManager.ClosePackage();
        NFTDetails.SetActive(true);
        DataParser(nftCellData);
        
    }

    public void BackToNFToPackage()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        NFTPackageManager.Package.SetActive(true);
        NFTDetails.SetActive(false);
        
    }

    public void ExitNFTPackage()
    {
        NFTPackageManager.ClosePackage();
        NFTDetails.SetActive(false);
    }


    private void DataParser(NFTCellData nftCellData)
    {
        CurrentMirror = nftCellData;
        SetImage(nftCellData.DataParsingEntity.image,nftHeader);

        nftID.text = nftCellData.DataParsingEntity.ID;

        nftContent.text = nftCellData.DataParsingEntity.description;


        foreach (var item in nftCellData.DataParsingEntity.attribute)
        {
            if (item.trait_type == "Rarity")
            {
                nftRarity.text = item.value;
            }
        }
     

    }
    
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

    public void NFTSetToBattle()
    {
        foreach (var item in CurrentMirror.DataParsingEntity.attribute)
        {
            if (item.trait_type == "Type")
            {
                PlayerPrefs.SetString("CurrentRole",item.value);
                
            }else if (item.trait_type == "Rarity")
            {
                PlayerPrefs.SetString("CurrentRarity",item.value);
            }
            
        }
        EventDispatcher.Instance.roleChanged?.Invoke();
    }

    public void ListNFT()
    {
        CallSDK.ListNFT(CurrentMirror);
        ExitNFTPackage();
    }
    
    
    public void TransferNFT()
    {
        CallSDK.TransferNFT(CurrentMirror);
        ExitNFTPackage();
    }
    
    
 

   
    
    
    
    
}
