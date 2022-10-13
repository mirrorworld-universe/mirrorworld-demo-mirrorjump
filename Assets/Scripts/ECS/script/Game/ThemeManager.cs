﻿
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public GameObject ThemeBack;
    public GameObject ThemeGroud;
    public GameObject ThemeCloud;
    

    public GameObject LockedBack;
    public GameObject Tips;

 

    public Sprite[] ThemeBackSprites = new Sprite[5];
    
    public Sprite[] ThemeGroudSprites = new Sprite[5];
    
    public Sprite[] ThemeCloudSprites = new Sprite[5];




    private int CurrentThemeIndex ;


    private bool IsLockCurrentTheme;


    public GameObject LeftPage;

    public GameObject RightPage;
    
    
    
    
    
    
    
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
        SoundManager.Instance.PlaySound(SoundName.Button);
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

        SoundManager.Instance.PlaySound(SoundName.TurnPage);
        RefreshLockState();
        
    }
    
    public void ToRightTheme()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        if ("false" == PlayerPrefs.GetString("HasGuidence", "false"))
        {
            return;
        }

        if (CurrentThemeIndex +1 > 4)
        {
            //  do some advice
            
            return;
        }
        
        PlayerPrefs.SetInt("CurrentTheme",CurrentThemeIndex+1);

        SoundManager.Instance.PlaySound(SoundName.TurnPage);
        RefreshLockState();
    }
    
    private void RefreshLockState()
    {   
        
        
        
        int SpriteIndex = PlayerPrefs.GetInt("CurrentTheme");

        if (SpriteIndex >= 4)
        {
            RightPage.gameObject.GetComponent<CanvasGroup>().alpha = 0.5f;
            RightPage.gameObject.GetComponent<Button>().interactable =false;
            
        }else if (SpriteIndex <= 0)
        {
            LeftPage.gameObject.GetComponent<CanvasGroup>().alpha = 0.5f;
            LeftPage.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            RightPage.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
            LeftPage.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
            LeftPage.gameObject.GetComponent<Button>().interactable = true;
            RightPage.gameObject.GetComponent<Button>().interactable =true;
        }
        
        ThemeBack.gameObject.GetComponent<Image>().sprite = ThemeBackSprites[SpriteIndex];
        ThemeGroud.gameObject.GetComponent<Image>().sprite = ThemeGroudSprites[SpriteIndex];
        ThemeCloud.gameObject.GetComponent<Image>().sprite = ThemeCloudSprites[SpriteIndex];
        
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
            
        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemePastureIndex)
        {
             LockState = PlayerPrefs.GetInt("ThemePastureState", 0); 
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
