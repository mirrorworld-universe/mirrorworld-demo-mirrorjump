
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public ThemeManager ThemeManager;


    private bool IsDebug = false;

    public void OnDebugClick()
    {
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
                LoginState.Name = LoginResponse.UserResponse.Username;
                LoginState.WalletAddress= LoginResponse.UserResponse.Wallet.SolAddress;
                LoginState.ID =  LoginResponse.UserResponse.Id.ToString();
            
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
