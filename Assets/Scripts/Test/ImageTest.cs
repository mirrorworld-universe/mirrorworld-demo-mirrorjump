
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour
{

    public ImageLoader ImageLoader;
    
    
    public void DownLoad()
    {
    
            ImageLoader.LoadImage(transform.gameObject.GetComponent<Image>());
     
          
    }
    
    private async void SetIMage()
    {
        Sprite sprite = await LoadHelper.LoadSprite("");
      
    }
    
    
    
}
