
using System;
using System.Collections.Generic;
using UnityEngine;

public class CallSDK : MonoBehaviour
{


    public RoleChange RoleChange;
    private void Start()
    {
        //ImagePreload();
    }

    public List<NFTCellData> FetchNFTS()
    {
        return MirrorSDK.FetchNfts();
        
    }
    
    
    // todo Just Simulate the SDK call operation
    public void MintNFT(NFTCellData nftCellData)
    {
        if (MirrorSDK.MintNFT(nftCellData))
        {
            PlayerPrefs.SetString("HasMintRandom", "true");
            string name = null;
            string rarity = null;
            foreach (var item in nftCellData.DataParsingEntity.attribute)
            {
                if (item.trait_type == "Rarity")
                {
                    rarity = item.value;
                    
                }else if (item.trait_type == "Type")
                {
                    name = item.value;
                }
            }
            RoleChange.OnRoleChange(name,rarity);
            
        }
        else
        {
            
        }
    }

    public void ListNFT(NFTCellData nftCellData)
    {
        if (MirrorSDK.ListNFT(nftCellData))
        {
            
        }
        else
        {
            
        }
    }


    public void TransferNFT(NFTCellData nftCellData)
    {
        if (MirrorSDK.TransferNFT(nftCellData))
        {
            
        }
        else
        {
            
        }
    }
    
    
    
    
    
    
    private void ImagePreload()
    {
        List<string> urls = new List<string>();

        List<string> roles = new List<string>();

        List<string> rarity = new List<string>();
        
        roles.Add(Constant.Astronaut);
        roles.Add(Constant.Samurai);
        roles.Add(Constant.PirateCaptain);
        roles.Add(Constant.CatMaid);
        roles.Add(Constant.Zombie);
        
        
        rarity.Add(Constant.Common);
        rarity.Add(Constant.Rare);
        rarity.Add(Constant.Elite);
        rarity.Add(Constant.Legendary);
        rarity.Add(Constant.Mythical);
        
   

        for (int i = 0; i < roles.Count; i++)
        {
            for (int j = 0; j < rarity.Count; j++)
            {
                urls.Add(Constant.ImagePrefix+rarity[j]+"_"+roles[i]+".png");
            }
        }

        for (int i = 0; i < urls.Count; i++)
        {
            ImageLoader.LoadSprite(urls[i]);
        }
        
        
        
    }
    
    
    
    
    
}
