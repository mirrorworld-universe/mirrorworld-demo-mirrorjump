using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackageDetailsManager : MonoBehaviour
{
    public Image Header;
    
    public TextMeshProUGUI Content;

    public TextMeshProUGUI Rarity;

    public TextMeshProUGUI RarityTitle;

    public GameObject SetToBattleTop;

    public GameObject SetToBattleBottom;

    public GameObject MintToNFT;

    public GameObject DetailsRoot;

    public GameObject Line;
    
    private NFTCellData CurrentMirror;
    
    public GameObject PackageDetails;

    public PackageManager PackageManager;
  
    public void OpenPackageDetails(NFTCellData nftCellData,bool IsCanMint)
    {  
        PackageManager.ClosePackage();
        PackageDetails.SetActive(true);
        DataParser(nftCellData); 
        
        if (IsCanMint)
        {
            LayoutCanMint();
            return;
        }
        
        LayoutDefault();
    }


    private void LayoutCanMint()
    {
        Rarity.gameObject.SetActive(true);
        RarityTitle.gameObject.SetActive(true);
        Line.SetActive(true);
        SetToBattleBottom.SetActive(true);
        MintToNFT.SetActive(true);
        
        SetToBattleTop.SetActive(false);

        DetailsRoot.transform.position =
            new Vector3(DetailsRoot.transform.position.x, 30, DetailsRoot.transform.position.z);
    }

    private void LayoutDefault()
    {
        Rarity.gameObject.SetActive(false);
        RarityTitle.gameObject.SetActive(false);
        Line.SetActive(false);
        SetToBattleBottom.SetActive(false);
        MintToNFT.SetActive(false);

        DetailsRoot.transform.position =
            new Vector3(DetailsRoot.transform.position.x, 0, DetailsRoot.transform.position.z);

    }
    
    

    public void BackToPackage()
    {
        PackageManager.Package.SetActive(true);
        PackageDetails.SetActive(false);
    }

    public void ExitPackage()
    {
        PackageManager.ClosePackage();
        PackageDetails.SetActive(false);
    }


    private void DataParser(NFTCellData nftCellData)
    {
        CurrentMirror = nftCellData;
        SetImage(nftCellData.DataParsingEntity.image,Header);
        
        Content.text = nftCellData.DataParsingEntity.description;
        
        
        foreach (var item in nftCellData.DataParsingEntity.attribute)
        {
            if (item.trait_type == "Rarity")
            {
                Rarity.text = item.value;
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

    public void SetToBattle()
    {
        // foreach (var item in CurrentMirror.DataParsingEntity.attribute)
        // {
        //     if (item.trait_type == "Type")
        //     {
        //         PlayerPrefs.SetString("CurrentRole",item.value);
        //         
        //     }else if (item.trait_type == "Rarity")
        //     {
        //         PlayerPrefs.SetString("CurrentRarity",item.value);
        //     }
        //     
        // }
    }


    public void MintNFT()
    {
        
    }
    
    

    
    
    
}