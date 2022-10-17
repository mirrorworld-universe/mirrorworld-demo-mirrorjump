
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public ThemeManager ThemeManager;
    
    


    public GameObject LoginButton;

    private void Start()
    {
        SoundManager.Instance.GetAudioSource().clip = SoundManager.Instance.Clips[5];
        SoundManager.Instance.GetAudioSource().mute = SoundManager.Instance.GetSoundState();
        SoundManager.Instance.GetAudioSource().Play();
    }


    // private void Start()
    // {
    //     // MirrorSDK.IsLoggedIn((result) =>
    //     // {
    //     //     if (result)
    //     //     {
    //     //         LoginButton.SetActive(false);
    //     //         SceneManager.LoadScene("Menu");
    //     //         
    //     //     }
    //     //  
    //     //     
    //     // });
    //     //
    //     
    //     
    // }

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
        
        SoundManager.Instance.GetAudioSource().mute = true;
        SoundManager.Instance.GetAudioSource().clip = null;
        
        SoundManager.Instance.GetAudioSource().mute = SoundManager.Instance.GetSoundState();
        
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
        SoundManager.Instance.PlaySound(SoundName.Button);
        MirrorSDK.OpenWalletPage();
    }

    public void ClearAllPersistingData()
    {
        PlayerPrefs.DeleteAll();
    }


    
}
