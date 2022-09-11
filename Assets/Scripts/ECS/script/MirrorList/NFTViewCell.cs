
using TMPro;
using UnityEngine;

public class NFTViewCell : MonoBehaviour
{
    public TextMeshProUGUI content;
    
    public void OnDataBind(NFTCellData nftCellData)
    {
        content.text = nftCellData.ID;
    }
}
