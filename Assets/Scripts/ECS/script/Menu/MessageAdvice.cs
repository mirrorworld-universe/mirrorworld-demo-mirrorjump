using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageAdvice : MonoBehaviour
{
   public TextMeshProUGUI MessageContent;

   public Sprite Success;

   public Sprite Failure;

   public Image Icon;

   public GameObject DialogRoot;
   
   public GameObject Confirm;





   public void OpenConfirm()
   {
      Confirm.SetActive(true);
   }


   public void CloseConfirm()
   {
      Confirm.SetActive(false);
   }
   public void ConfirmMint()
   {  
      
      
      PlayerPrefs.SetString("HasMintRandom", "true");
      CloseConfirm();
      OnSuccess("Congratulation!\n" +
                "Mint Successful!");
      
   }
   
   
   

   public void OnSuccess(string message)
   {
      Icon.sprite = Success;
      MessageContent.text = message;
      DialogRoot.SetActive(true);
   }


   public void OnFailure()
   {
      Icon.sprite = Failure;
      MessageContent.text = "ops!\nPlease try again!";
      DialogRoot.SetActive(true);
   }

   public void Exit()
   {
      DialogRoot.SetActive(false);
   }


}
