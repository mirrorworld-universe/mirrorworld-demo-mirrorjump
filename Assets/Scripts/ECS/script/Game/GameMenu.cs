using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{


    public GameObject GameOverWindow;

    public GameObject GamePauseWindow;

    public GameController GameController;

    public TextMeshProUGUI HighScore;


    public GameObject UnlockHeightAdvice;

    public GameObject UnlockAdvice;

    private bool IsHeightAdvice = false;
    private bool IsUnlockAdvice = false;
    private float CurrentTime = 0;

    private void Start()
    {
        HighScore.text = "0";
        OpenUnlockHeightAdvice();
        UnlockHeightAdvice.SetActive(false);
        UnlockAdvice.SetActive(false);
    }

    private void OpenUnlockHeightAdvice()
    {   
        
        if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeSpaceIndex)
        {
            if (1 == PlayerPrefs.GetInt("ThemeDesertState", 0))
            {
                return;
            }
            
        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeDesertIndex)
        {
            if (1 ==  PlayerPrefs.GetInt("ThemeSnowState", 0))
            {
                return;
            }
        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeSnowIndex)
        {    
            if (1 ==   PlayerPrefs.GetInt("ThemeCyberpunkState", 0))
            {
                return;
            }
            
        }else if (PlayerPrefs.GetInt("CurrentTheme") == Constant.ThemeCyberpunkIndex)
        {    
            if (1 ==   PlayerPrefs.GetInt("ThemePastureState", 0))
            {
                return;
            }
            
        }
        
        IsHeightAdvice = true;
        CurrentTime = 0;
        UnlockHeightAdvice.SetActive(true);
        
        
        
    }
    
    
    public void OpenUnlockAdvice()
    {
        IsUnlockAdvice = true;
        CurrentTime = 0;
        UnlockAdvice.SetActive(true);
        
    }

    


    private void Update()
    {
        
        if (IsHeightAdvice)
        {
            CurrentTime+=Time.deltaTime;
            if (CurrentTime >= 3)
            {
                IsHeightAdvice = false;
                CurrentTime = 0;
                UnlockHeightAdvice.SetActive(false);
            }
        }

        
        if (IsUnlockAdvice)
        {
            CurrentTime+=Time.deltaTime;
            if (CurrentTime >= 3)
            {
                IsUnlockAdvice = false;
                CurrentTime = 0;
                UnlockAdvice.SetActive(false);
            }
        }
        
        
        
       
        
        
    }
    
    
    


    public void GameOver()
    {
            GameOverWindow.SetActive(true);
            GameController.OnGameOver();
    }

    public void GamePause()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        GameController.OnGamePause();
      
        GamePauseWindow.SetActive(true);
        
    }

    public void GameResume()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        GamePauseWindow.SetActive(false);
        GameController.OnGameResume();
    }

    public void StartNewGame()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        GameController.StartNewGame();
    }

    public void CloseGameOverWindow()
    {
        SoundManager.Instance.PlaySound(SoundName.Close);
        GameOverWindow.SetActive(false);
    }

    public void SetHighScore(string score)
    {
        HighScore.text = score;
    }

    public void ExitGame()
    {
        SoundManager.Instance.PlaySound(SoundName.Close);
        SceneManager.LoadScene("Menu");
    }
   
}
