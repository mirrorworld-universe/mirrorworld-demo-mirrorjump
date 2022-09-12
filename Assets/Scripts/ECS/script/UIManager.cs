
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
   
   public ListView ListView;


   public CanvasGroup LeftPageTurningCanvas;

   public CanvasGroup RightPageTurningCanvas;

   public Button LeftPageTurning;

   public Button RightPageTurning;

   
   private void Start()
   {
      PageTurningStateUpdate(true);
   }


   public void OnTurningLeft()
   { 
       ListView.ToLeftPage();
      PageTurningStateUpdate(false);
   }

   public void OnTurningRight()
   {   ListView.ToRightPage();
       PageTurningStateUpdate(false);
   }


   public void PageTurningStateUpdate(bool IsFirst)
   {
       PageTurningState State = ListView.GetPageTurningState(IsFirst);

       if (State == PageTurningState.Both)
       {
           LeftPageTurningCanvas.alpha = 1;
           RightPageTurningCanvas.alpha = 1;
           
           // LeftPageTurning.SetEnabled(true);
           // RightPageTurning.SetEnabled(true);
           
       }else if (State == PageTurningState.None)
       {
           LeftPageTurningCanvas.alpha = 0;
           RightPageTurningCanvas.alpha = 0;
           
           // LeftPageTurning.SetEnabled(false);
           // RightPageTurning.SetEnabled(false);
           
       }else if (State == PageTurningState.OnlyLeft)
       {
           LeftPageTurningCanvas.alpha = 1;
           RightPageTurningCanvas.alpha = 0.5f;
           
           // LeftPageTurning.SetEnabled(true);
           // RightPageTurning.SetEnabled(false);
           
       }else if (State == PageTurningState.OnlyRight)
       {
           LeftPageTurningCanvas.alpha = 0.5f;
           RightPageTurningCanvas.alpha = 1;
           
           // LeftPageTurning.SetEnabled(false);
           // RightPageTurning.SetEnabled(true);
       }
      
       
   }
   
   



}
