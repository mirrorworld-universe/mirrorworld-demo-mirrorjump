

using System.Collections.Generic;
using MirrorworldSDK;
using MirrorworldSDK.Models;
using UnityEngine;

public class CallSDK : MonoBehaviour
{

    public MessageAdvice MessageAdvice;


    public RoleChange RoleChange;

    public NFTPackageManager NftPackageManager;







  
    

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
    
    
    
    
    // todo Just Simulate the SDK call operation
    public void MintNFT(NFTCellData nftCellData)
    {
        if (Mint())
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
    
    
    private bool Mint ()
    {
        if (LoginState.HasLogin)
        {
            string name = "Mirror Jump " + "#" + GetNameNumber(PlayerPrefs.GetString("MintUrl"));
            
            MirrorSDK.MintNFT("BXqCckKEidhJUpYrg4u2ocdiDKwJY3WujHvVDPTMf6nL",name,"MJNFT",PlayerPrefs.GetString("MintUrl"),Confirmation.Confirmed,
                (result) =>
                {
                    PlayerPrefs.SetString("HasMintNFT","true");
                    
                });

            return true;

        }
        return false;
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
