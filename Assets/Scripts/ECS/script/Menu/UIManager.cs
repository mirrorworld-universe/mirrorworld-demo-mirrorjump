using UnityEngine;
using UnityEngine.SceneManagement;

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
