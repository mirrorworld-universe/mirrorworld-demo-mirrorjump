using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{


    public GameObject GameOverWindow;

    public GameObject GamePauseWindow;
    
    
    

    public void GameOver()
    {
        if (!GameOverWindow.activeSelf)
        {
            GameOverWindow.SetActive(true);
        }
    }
   
}
