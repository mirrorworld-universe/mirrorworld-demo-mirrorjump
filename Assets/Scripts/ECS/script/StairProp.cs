using UnityEngine;


public class StairProp : MonoBehaviour
{
    
    public float VerticalVelocity = 10f;
   
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
     
}
