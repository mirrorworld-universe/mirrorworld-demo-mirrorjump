
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class LoadHelper
{
    

    public static async Task<Sprite> LoadSprite(string url)
    {
        var task = LoadAsyncSprite(url);
        Task<Sprite> t = await Task.WhenAny(task);
        return t.Result;
    }
    private static async Task<Sprite> LoadAsyncSprite(string url)
    {
        
    
        UnityWebRequest getRequest = UnityWebRequest.Get(url);
        getRequest.timeout = 5000;
        getRequest.certificateHandler = new WebRequestCertificate();
        
        await getRequest.SendWebRequest();

        if (getRequest.isNetworkError || getRequest.isHttpError)
        {
            return null;
        }
        
        byte[] imgData = getRequest.downloadHandler.data;
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imgData);
        tex.name = "";
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), pivot, 100.0f);
        
        return sprite;
    }
}
public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj =>
        {
            tcs.SetResult(null);
        };
        return ((Task)tcs.Task).GetAwaiter();
    }
}