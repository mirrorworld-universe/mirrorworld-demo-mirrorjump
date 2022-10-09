

using System.Collections.Generic;
using MirrorworldSDK;
using MirrorworldSDK.Models;
using UnityEngine;

public class CallSDK : MonoBehaviour
{

    public MessageAdvice MessageAdvice;


    public RoleChange RoleChange;

    public NFTPackageManager NftPackageManager;

    private NFTCellData NftCellData;







  
    
    // todo fetch nfts
    public void FetchNFTS()
    {
        if (LoginState.HasLogin)
        {

            List<string> creators = new List<string>();
            creators.Add(LoginState.WalletAddress);
            
            MirrorSDK.GetNFTsOwnedByAddress(creators, (Mutiple) =>
            {
                 List<NFTCellData> datas = new List<NFTCellData>();

                 for (int i = 0; i < Mutiple.Data.nfts.Count; i++)
                 {
                     NFTCellData nftCellData = new NFTCellData();
                     SingleNFTResponseObj NftData = Mutiple.Data.nfts[i];
                     nftCellData.NftData = NftData;
                     datas.Add(nftCellData);
                 }
                 NftPackageManager.RefreshData(datas);
                
            });
        }
    }
    
    
    
    
   // todo transfer token
    public void MintNFTResult(bool IsSuccess)
    {
        if (IsSuccess)
        {
            // transfer token
            MirrorSDK.TransferSol(0.5,"qS6JW1CKQgpwZU6jG5JpXL3Q4EDMoDD5DWacPEsNZoe",Confirmation.Confirmed, (result) =>
            {
                if (result.Status == "success")
                {
                    FinishedMint(true);
                }
                else
                {
                    FinishedMint(false);
                }
                
                
            });
            
            
        }
        else
        {
            MessageAdvice.OnFailure();
        }
        
    }


    private void FinishedMint(bool IsSuccess)
    {

        if (IsSuccess)
        {
            string name = null;
            string rarity = null;
            foreach (var item in NftCellData.DataParsingEntity.attribute)
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
            
            PlayerPrefs.SetString("HasMintRandom", "true");
            
            PlayerPrefs.SetString("HasMintNFT","true");
            
            MessageAdvice.OnSuccess("Successful!");
            
        }
        else
        {
            MessageAdvice.OnFailure();
        }
        
    }
    
    
    // todo Mint NFT
    public void MintNFT (NFTCellData nftCellData)
    {
        NftCellData = nftCellData;
        
        if (LoginState.HasLogin)
        {
            string name = "Mirror Jump " + "#" + GetNameNumber(PlayerPrefs.GetString("MintUrl"));
            
            MirrorSDK.MintNFT("BXqCckKEidhJUpYrg4u2ocdiDKwJY3WujHvVDPTMf6nL",name,"MJNFT",PlayerPrefs.GetString("MintUrl"),Confirmation.Confirmed,
                (result) =>
                {
                   

                   if (result.Status == "success")
                   {
                       MintNFTResult(true);
                   }
                   else
                   {
                       MintNFTResult(false);
                   }
                   
                });
            
        }
       
    }
    
    
    
    private string GetNameNumber(string target)
    {
     
        string res = "";
        int j = 59;
        while (j<target.Length)
        {   
            j++;
            
            if (target[j] == '.')
            {
                break;
            }
            res += target[j];
           
        }

        return res;
    }
    
    
    
    
}
