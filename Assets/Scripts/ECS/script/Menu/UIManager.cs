using System;
using System.Collections.Generic;
using cn.sharesdk.unity3d;
using MirrorworldSDK;
using MirrorworldSDK.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ 
    public void PlayGame()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        SceneManager.LoadScene("Game");
    }

    public void Login()
    {
        MirrorSDK.StartLogin((LoginResponse)=>
        {

            LoginState.HasLogin = true;
            LoginState.Name = LoginResponse.UserResponse.Username;
            LoginState.WalletAddress= LoginResponse.UserResponse.SolAddress;
            LoginState.ID =  LoginResponse.UserResponse.Id.ToString();
            
            
            
            SoundManager.Instance.PlaySound(SoundName.Button);
            SceneManager.LoadScene("Menu");
            
            
        });
    }

    public void OpenWallet()
    {
        MirrorSDK.OpenWalletPage();
        //ShareSDKManager.Instance.Share();
    }

    public void ClearAllPersistingData()
    {
        PlayerPrefs.DeleteAll();
    }


    
}
