using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{  
   
   // Track the threshold
   public float TrackThreshold;

   public GameObject MirrorRole;
   
   public MapRunSystem MapRunSystem;
   
   private float LastReferencePosition = 0;
    
   
   private float OddDistance = 19.144f;
   
   
   private bool IsGameOver = false;


   private void FixedUpdate()
   {
      // driver map move 
      if (transform.position.y - LastReferencePosition >= OddDistance)
         {
            LastReferencePosition = transform.position.y-ErrorReduction(transform.position.y - LastReferencePosition);
            MapRunSystem.MovingMap();
         }
      
}

   private float ErrorReduction(float delta)
   {
      return delta - OddDistance;
   }


   private void LateUpdate () 
   {
      if(!IsGameOver)
      {
         if (MirrorRole.transform.position.y > transform.position.y + TrackThreshold)
         {
            Vector3 TrackPosition = new Vector3(transform.position.x, MirrorRole.transform.position.y - TrackThreshold, transform.position.z);
            transform.position =TrackPosition;
         }
      }
   }
   
   
   
   
   
}
