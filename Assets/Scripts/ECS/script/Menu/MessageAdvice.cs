using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MessageAdvice : MonoBehaviour
{
   public TextMeshProUGUI MessageContent;

   public Sprite Success;

   public Sprite Failure;

   public Image Icon;

   public GameObject DialogRoot;
   
   public GameObject Confirm;

   public PackageDetailsManager PackageDetailsManager;


   public GameObject WaitPanel;

   public TextMeshProUGUI WaitTips;

   public GameObject ExitConfirmButton;
   
   
   public bool IsWaiting;

   private long time;
   private long timeLomp = 500;
   private string str = "";
   private string[] strs = { ".", "..", "..." };
   private int i = 0;

   public  TextMeshProUGUI WaitingText;
   


   private void Update()
   {
       if ( IsWaiting)
       {
           
           long now = GetTime();
           if (time < now)
           {  
               string text_ = str + strs[i % 3];
               WaitingText.text = text_;
               time = now + timeLomp;
               ++i;
           }

       }
   }
   
   private long GetTime()
   {
       //精确到毫秒
       return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
   }


   public void OpenConfirm()
   {
        SoundManager.Instance.PlaySound(SoundName.Pop);
        Confirm.SetActive(true);
   }


   public void CloseConfirm()
   {
        SoundManager.Instance.PlaySound(SoundName.Close);
        Confirm.SetActive(false);
   }
   public void ConfirmMint()
   { 
       CloseConfirm();
       // open wait panel
       OpenWaitPanel("Minting Now");
       
       PackageDetailsManager.MintNFT();
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
        SoundManager.Instance.PlaySound(SoundName.Close);
        DialogRoot.SetActive(false);
   }



   public void OpenWaitPanel(string tips)
   {
       WaitPanel.SetActive(true);
       WaitTips.text = tips;
       ExitConfirmButton.SetActive(false);
       str = WaitingText.text.ToString();
       IsWaiting = true;
   }


   public void CloseWaitPanel()
   {
       IsWaiting = false;
       WaitTips.text = "Are you sure to stop waiting ?";
       ExitConfirmButton.SetActive(true);
   }

   
   public void ConfrimCloseWaitPanel()
   {
       IsWaiting = false;
       WaitPanel.SetActive(false);
       
   }


}
