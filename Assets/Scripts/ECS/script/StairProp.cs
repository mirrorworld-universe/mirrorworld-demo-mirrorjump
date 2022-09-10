using UnityEngine;

public class StairProp : MonoBehaviour
{
   public float Jump_Force = 10f;
   
	 void OnCollisionEnter2D(Collision2D Other)
     {
         
         Rigidbody2D Rigid = Other.collider.GetComponent<Rigidbody2D>();

         if (Rigid != null)
         {
             Vector2 Force = Rigid.velocity;
             Force.y = Jump_Force;
             Rigid.velocity = Force;
         }
     }
     
     
    
}
