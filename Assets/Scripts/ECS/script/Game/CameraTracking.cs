using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraTracking : MonoBehaviour
{  
   
   public GameObject MirrorRole;
   
   public MapRunSystem MapRunSystem;

   public GameObject GameController;
   
   private float LastReferencePosition = 0;
    
   
   private float OddDistance = 19.144f;
   
   
   private bool IsGameOver = false;
   
   // Track the threshold
   private float UpperTrackThreshold = 2f;

   private float FloorTrackThreshold = 5.5f;
   
   private bool IsStartFall = false;

    private void FixedUpdate()
   {
      if (GameController.GetComponent<GameController>().GetGameState() == GameState.Gaming)
      {
         // driver map move 
         if (transform.position.y - LastReferencePosition >= OddDistance)
         {
            LastReferencePosition = transform.position.y-ErrorReduction(transform.position.y - LastReferencePosition);
            MapRunSystem.MovingMap();
         }
      }
      
}

   private float ErrorReduction(float delta)
   {
      return delta - OddDistance;
   }

   private void ErrorEliminate()
   {
      
   }


   private void LateUpdate () 
   {
      if(!IsGameOver)
      {
         if (MirrorRole.transform.position.y -  transform.position.y> UpperTrackThreshold)
         {   
            
            if (IsStartFall)
            {
               IsStartFall = false;
               MirrorRole.GetComponent<MirrorJump>().FallStateNotify(IsStartFall);
            }
            Vector3 TrackPosition = new Vector3(transform.position.x, MirrorRole.transform.position.y - UpperTrackThreshold, transform.position.z);
            transform.position =TrackPosition;
            return;
         }


         if (transform.position.y - MirrorRole.transform.position.y > FloorTrackThreshold || transform.position.y == 0)
         {
              // notify 
              if (!IsStartFall)
              {
                 IsStartFall = true;
                 // call method and notify
                 MirrorRole.GetComponent<MirrorJump>().FallStateNotify(IsStartFall);
              }

             
              // cancel tracking   
              // if (transform.position.y >= 0.1)
              // {
              //    // tracking
              //    float distance = Math.Abs(MirrorRole.transform.position.y - FloorTrackThreshold);
              //    Vector3 TrackPosition = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
              //    
              //    if (TrackPosition.y <= 0)
              //    {
              //       return;
              //    }
              //    transform.position =TrackPosition;
              //    
              // }
           
            
         }
         
         
      }
   }

   public void ResetCameraPosition()
   {
      Vector3 pos = transform.position;
      transform.position = new Vector3(pos.x, 0, pos.z);
      LastReferencePosition = 0;

   }
   
   
   
}
