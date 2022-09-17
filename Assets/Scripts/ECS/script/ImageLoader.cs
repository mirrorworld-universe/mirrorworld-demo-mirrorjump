

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    private Dictionary<string, Sprite> AllSprites = new Dictionary<string, Sprite>();


    private List<string> Urls = new List<string>();


    public void LoadImage(Image image)
    {
        // if (null != AllSprites[url])
        // {
        //     nftViewCell.Image.sprite = AllSprites[url];
        // }

       // StartCoroutine(ImageLoaderFromUrlTest(image));
        
       SetIMage(image);
    }
    
    private async void SetIMage(Image image)
    {
        Sprite sprite = await LoadHelper.LoadSprite("https://metadata-assets.mirrorworld.fun/mirror_jump/images/Common_Astronaut.png");
        image.sprite = sprite;

    }
    


    public IEnumerator ImageLoaderFromUrl(string url,NFTViewCell nftViewCell)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://metadata-assets.mirrorworld.fun/mirror_jump/images/Common_Astronaut.png");
        yield return request.SendWebRequest();
      
        if (request.downloadHandler.isDone)
        {
            var tex = DownloadHandlerTexture.GetContent(request);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, 180, 180), pivot, 100.0f);

            nftViewCell.Image.sprite = sprite;
            
            AllSprites.Add(url,sprite);
            
        }
      
    }
    
    // public IEnumerator ImageLoaderFromUrlTest(Image image)
    // {
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://metadata-assets.mirrorworld.fun/mirror_jump/images/Common_Astronaut.png");
    //     request.certificateHandler = new WebRequestCertificate();
    //     
    //     yield return request.SendWebRequest();
    //   
    //     if (request.downloadHandler.isDone)
    //     {
    //         var tex = DownloadHandlerTexture.GetContent(request);
    //         Vector2 pivot = new Vector2(0.5f, 0.5f);
    //         Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, 180, 180), pivot, 100.0f);
    //
    //        image.sprite = sprite;
    //         
    //       //  AllSprites.Add(url,sprite);
    //       
    //       
    //       
    //         
    //     }
    //   
    // }
    
    
    public IEnumerator ImageLoaderFromUrlTest(Image image)
    {
        UnityWebRequest wr = new UnityWebRequest("https://metadata-assets.mirrorworld.fun/mirror_jump/images/Common_Astronaut.png");
        DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
        wr.downloadHandler = texDl;
        yield return wr.SendWebRequest();
        
        if (wr.result == UnityWebRequest.Result.Success) {
            Texture2D t = texDl.texture;
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),
                Vector2.zero, 1f);
            image.sprite = s;
        }
        
        
      
    }

    

    
  
  

}
