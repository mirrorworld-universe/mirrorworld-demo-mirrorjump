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
    
    
    

    public void GameOver()
    {
            GameOverWindow.SetActive(true);
            GameController.OnGameOver();
    }

    public void GamePause()
    {
        GameController.OnGamePause();
        if (!GamePauseWindow.activeSelf)
        {
            GamePauseWindow.SetActive(true);
        }
    }

    public void GameResume()
    {   
        GamePauseWindow.SetActive(false);
        GameController.OnGameResume();
    }

    public void StartNewGame()
    {
        GameController.StartNewGame();
    }

    public void CloseGameOverWindow()
    {
        GameOverWindow.SetActive(false);
    }

    public void SetHighScore(string score)
    {
        HighScore.text = score;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
