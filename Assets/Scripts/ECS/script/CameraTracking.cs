using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{  
   
   // Track the threshold
   public float TrackThreshold;

   public GameObject MirrorRole;

   private bool IsGameOver = false;
   
   void LateUpdate () 
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
