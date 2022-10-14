

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


    public PackageManager PackageManager;


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





  
    
    // todo SDK Call  Fetch NFTS
    public void FetchNFTS()
    {
        if (LoginState.HasLogin)
        {
            List<string> creators = new List<string>();
            creators.Add(LoginState.WalletAddress);
            
            MirrorSDK.GetNFTsOwnedByAddress(creators, (Mutiple) =>
            {
                 List<NFTCellData> datas = new List<NFTCellData>();
                 for (int i = 0; i < Mutiple.data.nfts.Count; i++)
                 {
                     NFTCellData nftCellData = new NFTCellData();
                     SingleNFTResponseObj NftData = Mutiple.data.nfts[i];
                     nftCellData.NftData = NftData;
                     datas.Add(nftCellData);
                 }
                 NftPackageManager.RefreshData(datas);
            });
        }
    }
    
    
   // todo Transfer Token
    public void MintNFTResult(bool IsSuccess)
    {   
        if (IsSuccess)
        {
            // transfer token
            MirrorSDK.TransferSol(100000000,"qS6JW1CKQgpwZU6jG5JpXL3Q4EDMoDD5DWacPEsNZoe",Confirmation.Confirmed, (result) =>
            {
                if (result.status == "success")
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
        
        {   MessageAdvice.ConfrimCloseWaitPanel();
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
            
            MessageAdvice.ConfrimCloseWaitPanel();
            MessageAdvice.OnSuccess("Mint Successful!");
            PackageManager.RefreshPackage();
            
        }
        else
        {   
            MessageAdvice.ConfrimCloseWaitPanel();
            MessageAdvice.OnFailure();
        }
        
        
        //  todo 解锁  Mint Api 限制状态
        ApiCallLimit.SetMintApiLimit(Constant.StopMint);
        
        
    }
    
    // todo SDK Call MintNFT
    public void MintNFT (NFTCellData nftCellData)
    {    
        
        
        
        NftCellData = nftCellData;
        
        if (LoginState.HasLogin)
        {
            string name = "Mirror Jump " + "#" + GetNameNumber(PlayerPrefs.GetString("MintUrl"));
            
            if (ApiCallLimit.MintLimit() == false)
            {
                MessageAdvice.OpenWaitPanel("Mint Now");
                return;
            }
            
            ApiCallLimit.SetMintApiLimit(Constant.ExecuteMint);
            
            MessageAdvice.OpenWaitPanel("Mint Now");
            
            MirrorSDK.MintNFT("BXqCckKEidhJUpYrg4u2ocdiDKwJY3WujHvVDPTMf6nL",name,"MJNFT",PlayerPrefs.GetString("MintUrl"),Confirmation.Confirmed,
                (result) =>
                {
                    
                   if (result.status == "success")
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
    
    
    
  
    
    
    
}
