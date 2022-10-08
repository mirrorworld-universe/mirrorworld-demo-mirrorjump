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
    private int FremeCount = 0;

    private void Start()
    {
        HighScore.text = "0";
        OpenUnlockHeightAdvice();
    }

    private void OpenUnlockHeightAdvice()
    {
        IsHeightAdvice = true;
        FremeCount = 0;
        UnlockHeightAdvice.SetActive(true);
    }
    
    
    public void OpenUnlockAdvice()
    {
        IsUnlockAdvice = true;
        FremeCount = 0;
        UnlockAdvice.SetActive(true);
        
    }

    


    private void Update()
    {
        if (IsHeightAdvice)
        {
            FremeCount++;
            if (FremeCount >= 1000)
            {
                IsHeightAdvice = false;
                FremeCount = 0;
                UnlockHeightAdvice.SetActive(false);
            }
            
            
            
        }
        
        
        if (IsUnlockAdvice)
        {
            FremeCount++;
            if (FremeCount >= 1000)
            {
                IsUnlockAdvice = false;
                FremeCount = 0;
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
