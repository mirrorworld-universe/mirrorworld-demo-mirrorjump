
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NFTViewCell : MonoBehaviour
{
    
    public Image Image;

    private Sprite defaultSprite;

    public NFTCellData NftCellData;
    
    public void OnDataBind(NFTCellData nftCellData,Sprite sprite)
    {
        NftCellData = nftCellData;
        Image.sprite = sprite;
        defaultSprite = sprite;
        SetImage(NftCellData.DataParsingEntity.image);
        
    }
    
    private async void SetImage(string url)
    {  
        if(null != Image)
        {
           Sprite sprite = await LoadHelper.LoadSprite(url);
           
           if (null != sprite && transform.gameObject.activeSelf)
           {
               Image.sprite = sprite;
           }
           else
           {
               Image.sprite = defaultSprite;
           }
        }
       
    }
    
}
