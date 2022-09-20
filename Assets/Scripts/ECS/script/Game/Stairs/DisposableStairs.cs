using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableStairs : MonoBehaviour
{
    public float VerticalVelocity = 10f;

    private float HeightOffset = 0.19f;

    private float RecoveryLine = 0;
    
    private GameController GameController;

    public SpriteRenderer SpriteRenderer;

    private float AlphaChangeDelta = 0.1f;

    private bool IsStartDisappear = false;
    
    
    public void SetGameController(GameController gameController)
    {
        GameController = gameController;
    }
   
    private void OnCollisionEnter2D(Collision2D Other)
    {
        Rigidbody2D Rigid = Other.collider.GetComponent<Rigidbody2D>();

        if (Rigid != null)
        {   
            GetComponent<AudioSource>().Play();
            Vector2 Force = Rigid.velocity;
            Force.y = VerticalVelocity;
            Rigid.velocity = Force;
            
            IsStartDisappear = true;
          
        }
    }


    private void DisappearStart()
    {
        if (null != SpriteRenderer)
        {
            SpriteRenderer.color = new Vector4(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b,
                SpriteRenderer.color.a - AlphaChangeDelta);

            if (SpriteRenderer.color.a <= 0.1)
            {
                Disappear();
            }
        }
    }


    private void Disappear()
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<PlatformEffector2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
     
     
    // stairs collection 
    private void FixedUpdate()
    {

        if (GameController.GetGameState() == GameState.Gaming)
        {
            RecoveryLine =  Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

            if (RecoveryLine - transform.position.y >= HeightOffset)
            {
                DestroyStairs();
            }

            if (IsStartDisappear)
            {
                DisappearStart();
            }
            
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