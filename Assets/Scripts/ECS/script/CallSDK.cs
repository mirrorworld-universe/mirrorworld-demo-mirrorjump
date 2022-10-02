

using System.Collections.Generic;
using MirrorworldSDK;
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
                Mutiple.Data.nfts[0].
                List<NFTCellData> datas = new List<NFTCellData>();
                NftPackageManager.RefreshData(datas);

            });
        }
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
    
    
    private bool Mint ()
    {
        if (LoginState.HasLogin)
        {
            
          //  MirrorSDK.MintNFT("BXqCckKEidhJUpYrg4u2ocdiDKwJY3WujHvVDPTMf6nL",,":MWJ",Confirmation.Confirmed);
        }

        return false;
        
        
    }
    
    
    
    
    
    
}
