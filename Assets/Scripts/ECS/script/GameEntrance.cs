using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameEntrance : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

   
    
    
    



    private void Start()
    {

        StartPlay();
    }


    public void StartPlay()
    {
        videoPlayer.loopPointReached += OnVideoFinished;//添加播放结束事件
        videoPlayer.Play();
      
    }


    private void OnVideoFinished(VideoPlayer source)
    {  
        videoPlayer.Pause();
        
        StartCoroutine(ASynHidePanel());

    }

    IEnumerator ASynHidePanel()
    {
        yield return new WaitForSeconds(0.5f);
        videoPlayer.targetTexture.Release();
         videoPlayer.gameObject.SetActive(false);
         SceneManager.LoadScene("Login");
         
         
    }
    
    
}
