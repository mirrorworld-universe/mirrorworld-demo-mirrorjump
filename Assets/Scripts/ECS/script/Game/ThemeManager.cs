
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public GameObject ThemeBack;
    public GameObject ThemeGroud;
    public GameObject ThemeCloud;
    

    public GameObject LockedBack;
    public GameObject Tips;

 

    public Sprite[] ThemeBackSprites = new Sprite[4];
    
    public Sprite[] ThemeGroudSprites = new Sprite[4];
    
    public Sprite[] ThemeCloudSprites = new Sprite[4];




    private int CurrentThemeIndex ;


    private bool IsLockCurrentTheme;
    
    
    
    
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("CurrentTheme",-1) == -1)
        {
           PlayerPrefs.SetInt("CurrentTheme",Constant.ThemeSpaceIndex);
        }
        RefreshLockState();
        
    }
    
    public void ToLeftTheme()
    {
        if ("false" == PlayerPrefs.GetString("HasGuidence", "false"))
        {
            return;
        }
        
        if (CurrentThemeIndex - 1 < 0)
        {
            //  do some advice
            return;
        }
        
        PlayerPrefs.SetInt("CurrentTheme",CurrentThemeIndex-1);
        
        RefreshLockState();
        
    }
    
    public void ToRightTheme()
    {   
        
        if ("false" == PlayerPrefs.GetString("HasGuidence", "false"))
        {
            return;
        }

        if (CurrentThemeIndex +1 > 3)
        {
            //  do some advice
            return;
        }
        
        PlayerPrefs.SetInt("CurrentTheme",CurrentThemeIndex+1);
        
        RefreshLockState();
    }
    
    private void RefreshLockState()
    {
        int SpriteIndex = PlayerPrefs.GetInt("CurrentTheme");
        
        ThemeBack.gameObject.GetComponent<Image>().sprite = ThemeBackSprites[SpriteIndex];
        ThemeGroud.gameObject.GetComponent<Image>().sprite = ThemeGroudSprites[SpriteIndex];
        
        if (LockState())
        {
            IsLockCurrentTheme = true;
            LockedBack.SetActive(true);
            Tips.SetActive(true);
            
        }
        else
        {
            IsLockCurrentTheme = false;
            LockedBack.SetActive(false);
            Tips.SetActive(false);
            
        }
        
        CurrentThemeIndex = PlayerPrefs.GetInt("CurrentTheme");
    }
    
    private bool LockState()
    {
        int LockState = 1;

        if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeDesertIndex)
        {
            LockState = PlayerPrefs.GetInt("ThemeDesertState", 0);

        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeSnowIndex)
        {
            LockState = PlayerPrefs.GetInt("ThemeSnowState", 0);
            
        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeCyberpunkIndex)
        {
            LockState = PlayerPrefs.GetInt("ThemeCyberpunkState", 0);
        }


        if (LockState == 0)
        {
            return true;
        }

        return false;
        
    }


    public bool GetCurrentLockState()
    {
        return IsLockCurrentTheme;
    }
    
    
}
