
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
    
    
    
    
    
    
    
    
    
    
    
}
