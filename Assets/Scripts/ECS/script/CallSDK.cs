
using System;
using System.Collections.Generic;
using UnityEngine;

public class CallSDK : MonoBehaviour
{

    public MessageAdvice MessageAdvice;


    public RoleChange RoleChange;
    private void Start()
    {
        //ImagePreload();
    }

    public List<NFTCellData> FetchNFTS()
    {
        return MirrorSDKFake.FetchNfts();
        
    }
    
    
    // todo Just Simulate the SDK call operation
    public void MintNFT(NFTCellData nftCellData)
    {
        if (MirrorSDKFake.MintNFT(nftCellData))
        {  
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
            
            MessageAdvice.OpenConfirm();

        }
        else
        {
            MessageAdvice.OnFailure();
        }
    }

    public void ListNFT(NFTCellData nftCellData)
    {
        if (MirrorSDKFake.ListNFT(nftCellData))
        {
            MessageAdvice.OnSuccess("Congratulation!\n" +
                                    "List Successful!");
        }
        else
        {
            MessageAdvice.OnFailure();
        }
    }


    public void TransferNFT(NFTCellData nftCellData)
    {
        if (MirrorSDKFake.TransferNFT(nftCellData))
        {
            MessageAdvice.OnSuccess("Congratulation!\n" +
                                    "Transfer Successful!");
        }
        else
        {
            MessageAdvice.OnFailure();
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
