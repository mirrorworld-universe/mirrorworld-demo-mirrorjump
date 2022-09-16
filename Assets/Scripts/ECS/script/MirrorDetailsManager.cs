
using UnityEngine;
using UnityEngine.UI;

public class MirrorDetailsManager : MonoBehaviour
{



    public GameObject PackageDetails;

 

    public GameObject NFTDetails;

    public GameObject TopSetToBattle;

    public GameObject BottomSetToBattle;


    public GameObject Rarity;

    public GameObject RarityContent;
    
    public GameObject MintToNFT;


    public GameObject RoleImage;

    public RolePersistence RolePersistence;

  
    


    // todo l临时测试 待完善
    public void SetToBattle()
    {

        if ( null != PlayerPrefs.GetString("CurrentPlayer"))
        {
            if ("Other" == PlayerPrefs.GetString("CurrentPlayer"))
            {
                PlayerPrefs.SetString("CurrentPlayer","Replace");
            }
            else
            {
                PlayerPrefs.SetString("CurrentPlayer","Other");
            }
            
            RoleImage.GetComponent<Image>().sprite = RolePersistence.GetCurrentJumpPlayer();
        }
      
        
     

    }
    
    
    


    public void CloseDefaultPackageDetails()
    {
        PackageDetails.SetActive(false);
    }

    public void ClosePackageDetails()
    {
        PackageDetails.SetActive(false);
    }


    public void CloseNFTPackageDetails()
    {
        NFTDetails.SetActive(false);
    }
    
    
    public void PopDefaultPackageDetails()
    {
        TopSetToBattle.SetActive(true);
        Rarity.SetActive(false);
        RarityContent.SetActive(false);
        
        BottomSetToBattle.SetActive(false);
        MintToNFT.SetActive(false);
        
        PackageDetails.SetActive(true);
        
    }


    public void PopPackageDetails()
    {
        TopSetToBattle.SetActive(false);
        Rarity.SetActive(true);
        RarityContent.SetActive(true);
        
        BottomSetToBattle.SetActive(true);
        MintToNFT.SetActive(true);
        
        PackageDetails.SetActive(true);
    }


    public void NFTPackageDetails()
    {
        NFTDetails.SetActive(true);
    }
    
    
    
    
}
