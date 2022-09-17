
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
  
    public void OpenNFTPackageDetails(NFTCellData nftCellData)
    {   
        NFTPackageManager.ClosePackage();
        NFTDetails.SetActive(true);
        DataParser(nftCellData);
    }

    public void BackToNFToPackage()
    {
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
        
        Sprite sprite = await LoadHelper.LoadSprite(url);
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
    }
    
    
    // package
    
    
    
    
    
    // public GameObject PackageDetails;
    //
    // public void SetToBattle()
    // {
    //
    //     if ( null != PlayerPrefs.GetString("CurrentPlayer"))
    //     {
    //         if ("Other" == PlayerPrefs.GetString("CurrentPlayer"))
    //         {
    //             PlayerPrefs.SetString("CurrentPlayer","Replace");
    //         }
    //         else
    //         {
    //             PlayerPrefs.SetString("CurrentPlayer","Other");
    //         }
    //         
    //         RoleImage.GetComponent<Image>().sprite = RolePersistence.GetCurrentJumpPlayer();
    //     }
    //   
    //     
    //  
    //
    // }
    //
    //
    //
    //
    //
    // public void CloseDefaultPackageDetails()
    // {
    //     PackageDetails.SetActive(false);
    // }
    //
    // public void ClosePackageDetails()
    // {
    //     PackageDetails.SetActive(false);
    // }
    //
    //
    // public void CloseNFTPackageDetails()
    // {
    //     NFTDetails.SetActive(false);
    // }
    //
    //
    // public void PopDefaultPackageDetails()
    // {
    //     TopSetToBattle.SetActive(true);
    //     Rarity.SetActive(false);
    //     RarityContent.SetActive(false);
    //     
    //     BottomSetToBattle.SetActive(false);
    //     MintToNFT.SetActive(false);
    //     
    //     PackageDetails.SetActive(true);
    //     
    // }
    //
    //
    // public void PopPackageDetails()
    // {
    //     TopSetToBattle.SetActive(false);
    //     Rarity.SetActive(true);
    //     RarityContent.SetActive(true);
    //     
    //     BottomSetToBattle.SetActive(true);
    //     MintToNFT.SetActive(true);
    //     
    //     PackageDetails.SetActive(true);
    // }
    //

   
    
    
    
    
}
