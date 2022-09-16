
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
    
    
    
}
