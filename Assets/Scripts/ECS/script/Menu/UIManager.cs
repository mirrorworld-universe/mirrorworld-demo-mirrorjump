using System.Collections.Generic;
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
        MirrorSDK.StartLogin((LoginResponse)=> {
            
            
            PlayerPrefs.SetString("HasLogin","true");
            PlayerPrefs.SetString("name",LoginResponse.UserResponse.Username);
            PlayerPrefs.SetString("walletAddress",LoginResponse.UserResponse.SolAddress);
            PlayerPrefs.SetString("ID",LoginResponse.UserResponse.Id.ToString());
            
            SoundManager.Instance.PlaySound(SoundName.Button);
            SceneManager.LoadScene("Menu");
            
            
        });
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
