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
        //string apiKey = "mw_testAmRKdRbBsBbIAw3CeMqS9GORmcG5BRUCU4D";
        //MirrorworldSDK.MirrorSDK.InitSDK(apiKey,gameObject,true,MirrorworldSDK.MirrorEnv.StagingDevNet);
        MirrorworldSDK.MirrorSDK.StartLogin((success)=> {
            SoundManager.Instance.PlaySound(SoundName.Button);
            SceneManager.LoadScene("Menu");
        });
    }

    public void OpenWallet()
    {
        MirrorworldSDK.MirrorSDK.OpenWalletPage();
    }

    public void ClearAllPersistingData()
    {
        PlayerPrefs.DeleteAll();
    }
}
