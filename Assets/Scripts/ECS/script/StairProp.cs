using System;
using UnityEngine;


public class StairProp : MonoBehaviour
{
    
    public float VerticalVelocity = 10f;

    private float HeightOffset = 0.19f;

    private float RecoveryLine = 0;
   
	 private void OnCollisionEnter2D(Collision2D Other)
     {
         Rigidbody2D Rigid = Other.collider.GetComponent<Rigidbody2D>();

         if (Rigid != null)
         {
             Vector2 Force = Rigid.velocity;
             Force.y = VerticalVelocity;
             Rigid.velocity = Force;
         }
     }
     
     
     // stairs collection 
     private void FixedUpdate()
     {
         RecoveryLine =  Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

         if (RecoveryLine - transform.position.y >= HeightOffset)
         {
             DestroyStairs();
         }
         
     }

     private void DestroyStairs()
     {   
         GetComponent<EdgeCollider2D>().enabled = false;
         GetComponent<PlatformEffector2D>().enabled = false;
         GetComponent<SpriteRenderer>().enabled = false;
         
         Destroy(gameObject);
     }
     
}
