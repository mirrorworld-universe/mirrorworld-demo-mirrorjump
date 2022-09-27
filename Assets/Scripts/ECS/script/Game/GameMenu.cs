﻿using System.Collections;
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

    private void Start()
    {
        HighScore.text = "0";
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
