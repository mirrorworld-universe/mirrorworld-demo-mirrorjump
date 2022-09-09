using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorJump : MonoBehaviour
{
    
    public Sprite[] Spr_Player = new Sprite[2];

    public float OffsetOfBoundary = 0.8f;
    
    private float HorizontalVelocity = 0;

    private Rigidbody2D rigidbody2D = null;


   
    private void Update () 
    {    
        // wille be delete before export to Android
         KeyboardControl();
         GyroscopeControl();
         
    }
    
    private  void FixedUpdate()
    {
        if (rigidbody2D == null)
        {
            rigidbody2D = transform.gameObject.GetComponent<Rigidbody2D>();
        }
        
        Vector2 Velocity = rigidbody2D.velocity;
        Velocity.x = HorizontalVelocity;
        rigidbody2D.velocity = Velocity;

        MirrorJumpState(Velocity.y);
        
    }
    
    
    // keyboard control     in debug mode use this method
    private void KeyboardControl()
    {
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {
            this.HorizontalVelocity = -0.5f;
        }else if (!Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            this.HorizontalVelocity = 0.5f;
        }
        
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.HorizontalVelocity = 0f;
        }

        

    } 
    
    
    // gyroscope control   in Android platform use this method
    private void GyroscopeControl()
    {
        this.HorizontalVelocity = this.HorizontalVelocity * Input.acceleration.x;

        float LocalScaleX = transform.localScale.x;
        
        if (HorizontalVelocity > 0)
        {
            transform.localScale = new Vector3(LocalScaleX,transform.localScale.y,transform.localScale.z);
            
        }else if (HorizontalVelocity < 0)
        {
            transform.localScale = new Vector3(-LocalScaleX, transform.localScale.y, transform.localScale.z);
            
        }
    }
    
    
    private void MirrorJumpState(float verticalVelocity)
    {
        if (verticalVelocity > 0)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[0];
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {   
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[1];
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        }
        
        BoundaryRestrictions();
        
    }
    
    // Boundary restrictions
    private void BoundaryRestrictions()
    {
        Vector3 ZeroScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        if (transform.position.x > -ZeroScreen.x + OffsetOfBoundary)
            transform.position = new Vector3(ZeroScreen.x - OffsetOfBoundary, transform.position.y, transform.position.z);
        else if(transform.position.x < ZeroScreen.x -OffsetOfBoundary)
            transform.position = new Vector3(-ZeroScreen.x + OffsetOfBoundary, transform.position.y, transform.position.z);
    }

    
}
