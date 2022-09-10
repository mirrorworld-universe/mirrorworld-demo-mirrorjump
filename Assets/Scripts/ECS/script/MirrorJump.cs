using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorJump : MonoBehaviour
{
    
    public Sprite[] Spr_Player = new Sprite[2];

    public float OffsetOfBoundary = 0.8f;
    
    

    public float Vy = 0;
    
    
    private float HorizontalVelocity =0f;
    
    private float SpeedValue = 30f;

    Rigidbody2D rigidbody2D = null;

    private Vector3 MirrorLocalScale;
    
  
    
 

    private void Start()
    {
        rigidbody2D = transform.gameObject.GetComponent<Rigidbody2D>();
        MirrorLocalScale = transform.localScale;
    }


    private void Update () 
    {    
        GyroscopeControl();
        // wille be delete before export to Android
        // KeyboardControl();

    }
    
    private  void FixedUpdate()
    {
      
        
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
        this.HorizontalVelocity = SpeedValue * Input.acceleration.x;

        float LocalScaleX = transform.localScale.x;
        
        if (HorizontalVelocity > 0)
        {
            transform.localScale = new Vector3(MirrorLocalScale.x,MirrorLocalScale.y,MirrorLocalScale.z);
            
        }else if (HorizontalVelocity < 0)
        {
            transform.localScale = new Vector3(-MirrorLocalScale.x, MirrorLocalScale.y, MirrorLocalScale.z);
            
        }
    }
    
    
    private void MirrorJumpState(float verticalVelocity)
    {
        if (verticalVelocity > 0)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[0];
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {   
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[1];
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
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
