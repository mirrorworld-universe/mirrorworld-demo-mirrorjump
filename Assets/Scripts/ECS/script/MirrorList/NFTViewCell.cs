
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NFTViewCell : MonoBehaviour
{
    
    public Image Image;
    
    public void OnDataBind(NFTCellData nftCellData,Sprite sprite)
    {
        Image.sprite = sprite;
        
    }
}
