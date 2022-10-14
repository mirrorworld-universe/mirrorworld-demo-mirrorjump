
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public ThemeManager ThemeManager;


    private void Start()
    {
        MirrorSDK.IsLoggedIn((result) =>
        {
             
        });
        
        
        
    }

    private bool IsDebug = false;

    public void OnDebugClick()
    {   
        
        
        Debug.LogWarning("click");
        IsDebug = true;
        
    }
    
    public void PlayGame()
    {    
        if (ThemeManager.GetCurrentLockState())
        {   
            // add some tips 
            return;
        }
        
        SoundManager.Instance.PlaySound(SoundName.Button);
        SceneManager.LoadScene("Game");
    }

    public void Login()
    {
        
       

        if (IsDebug)
        {
            SoundManager.Instance.PlaySound(SoundName.Button);
            SceneManager.LoadScene("Menu");
        }
        else
        {   
            
         
            MirrorSDK.StartLogin((LoginResponse)=>
            {
                
                LoginState.HasLogin = true;
                LoginState.Name = LoginResponse.user.username;
                LoginState.WalletAddress= LoginResponse.user.wallet.sol_address;
                LoginState.ID =  LoginResponse.user.id.ToString();
                SoundManager.Instance.PlaySound(SoundName.Button);
                SceneManager.LoadScene("Menu");
            
            });
        }
        
       
    }

    public void OpenWallet()
    {
        MirrorSDK.OpenWalletPage();
    }

    public void ClearAllPersistingData()
    {
        PlayerPrefs.DeleteAll();
    }


    
}
