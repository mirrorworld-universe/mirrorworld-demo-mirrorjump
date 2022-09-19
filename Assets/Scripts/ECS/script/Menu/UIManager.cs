

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
   

    public void PlayGame()
   {
       SceneManager.LoadScene("Game");
   }

    public void Login()
    {
        SceneManager.LoadScene("Menu");
    }



    public void ClearAllPersistingData()
    {
        PlayerPrefs.DeleteAll();
    }
   



}
