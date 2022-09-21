using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorJump : MonoBehaviour
{
    
    public Sprite[] Spr_Player = new Sprite[2];

    public float OffsetOfBoundary = 0.8f;
    
    public GameObject GameController;

   
    
    // Spring
    
    public GameObject Spring;

    public GameObject SpringJump;

    public int SpringUseCount = 0;

    private int UseCount = 5;

    private bool HasSpring = false;
    
    public float SpringForce =10f;
    


    public void SetSpringState(bool hasSpring)
    {
        HasSpring = hasSpring;
    }


    public void ResetSpringUseCount()
    {
        SpringUseCount = 0;
    }

    public bool GetSpringState()
    {
        return HasSpring;
    }

    public void UseSpring()
    {
        SpringUseCount++;
        if (SpringUseCount >= UseCount)
        {
            SpringUseCount = 0;
            HasSpring = false;
        }
        
       
    }
    
    
    // Spring position adjust
    // 宇航 女仆
    private Vector2 SpringPostion1 = new Vector2(0.24f, -3.17f);
    // other
    private Vector2 SpringPostion2 = new Vector2(0.32f ,-3.43f);
    
    // 武士 海盗
    private Vector2 SpringJumpPostion1 = new Vector2(0.62f, -2.75f);
    
   // 女仆 宇航员
    private Vector2 SpringJumpPostion2 = new Vector2(0.41f, -2.53f);
    
    // 僵尸
    private Vector2 SpringJumpPostion3 = new Vector2(-0.23f ,-3.05f);


    private void SetSpringState()
    {
        if (HasSpring)
        {    
            Spring.SetActive(true);
            if (PlayerPrefs.GetString("CurrentRole") == Constant.Samurai ||
                PlayerPrefs.GetString("CurrentRole") == Constant.Zombie || PlayerPrefs.GetString("CurrentRole") == Constant.PirateCaptain)
            {
                Spring.transform.localPosition =
                    new Vector3(SpringPostion2.x, SpringPostion2.y, Spring.transform.localPosition.z);
            }
            else
            {
                Spring.transform.localPosition =
                    new Vector3(SpringPostion1.x, SpringPostion1.y, Spring.transform.localPosition.z);
            }
        }
        
    }
    
    private void SetSpringJumpState()
    {
        if (HasSpring)
        {   
            SpringJump.SetActive(true);
            if (PlayerPrefs.GetString("CurrentRole") == Constant.Samurai ||
                PlayerPrefs.GetString("CurrentRole") == Constant.PirateCaptain)
            {
                SpringJump.transform.localPosition =
                    new Vector3(SpringJumpPostion1.x, SpringJumpPostion1.y, Spring.transform.localPosition.z);
            }
            else if(PlayerPrefs.GetString("CurrentRole") == Constant.Zombie)
            {
                SpringJump.transform.localPosition =
                    new Vector3(SpringJumpPostion3.x, SpringJumpPostion3.y, Spring.transform.localPosition.z);
            }
            else
            {
                SpringJump.transform.localPosition =
                    new Vector3(SpringJumpPostion2.x, SpringJumpPostion2.y, Spring.transform.localPosition.z);
            }
        }
        
    }
    
    
    
    
    // Black Hole
    private bool IsEnterBlackHole = false;

    private float SinValue;

    private float ConsValue;
    
    private float BlackGravity = 2f;

    private Vector2 BlackHolePos;

    private float VX;

    private float VY;
    

    public void EnterHole(Vector2 HolePosition)
    {
        // calculate...
    
        IsEnterBlackHole = true;
        
        transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        BlackHolePos = HolePosition;

        VX = BlackGravity * GetCosValue(HolePosition);

        VY = BlackGravity * GetSinValue(HolePosition);
        
        // direct state

        if (transform.position.y - HolePosition.y > 0)
        {
            VY = -VY;
        }

        if (transform.position.x - HolePosition.x > 0)
        {
            VX = -VX;
        }


    }

    private float GetSinValue(Vector2 HolePos)
    {   
        float a = Math.Abs(HolePos.y - transform.position.y);
        return a / GetC(HolePos);
        
    }

    private float GetCosValue(Vector2 HolePos)
    {
        float b = Math.Abs(HolePos.x - transform.position.x);
        return b / GetC(HolePos);
    }


    private float GetC(Vector2 HolePos)
    {  
        
        float a = Math.Abs(HolePos.y - transform.position.y);
        
        float b = Math.Abs(HolePos.x - transform.position.x);

        return (float) Math.Sqrt(a * a + b * b);

    }
    
    
    

    
    
    
    

 
    
    
    private float HorizontalVelocity =0f;
    
    private float SpeedValue = 15f;

    Rigidbody2D rigidbody2D = null;

    private Vector3 MirrorLocalScale;
    
    private bool FallState = false;

    private float ReferencePosition = 0;

    private float DeathLength = 12f;

    private float TowardThreshold = 1.5f;

    public GameMenu GameMenu;
    
    
    
    

    public void FallStateNotify(bool state)
    {
        FallState = state;
        if (state)
        {
            ReferencePosition = transform.position.y;
        }
    }
    
  
    
 

    private void Start()
    {
        rigidbody2D = transform.gameObject.GetComponent<Rigidbody2D>();
        MirrorLocalScale = transform.localScale;
    }


    private void Update () 
    {
        
        if (GameController.GetComponent<GameController>().GetGameState() == GameState.Gaming)
        {
         // GyroscopeControl();
            // wille be delete before export to Android
           KeyboardControl();
            if (FallState)
            {
                if (transform.position.y < ReferencePosition)
                {
                    float y = transform.position.y;
                    if (Math.Abs(transform.position.y - ReferencePosition) >= DeathLength)
                    {
                        // Game over
                        GameMenu.GameOver();
                        FallState = false;
                    }
                }
            }
            
        }
      

    }
    private  void FixedUpdate()
    {

        if (GameController.GetComponent<GameController>().GetGameState() == GameState.Gaming)
        {

            if (IsEnterBlackHole)
            {
                Vector2 V = rigidbody2D.velocity;
                V.x = VX;
                V.y = VY;
                rigidbody2D.velocity = V;

                if (transform.localScale.x >= 0.02)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f,
                        transform.localScale.z - 0.005f);
                }
                else
                {
                    VX = 0;
                    VY = 0;
                    GameMenu.GameOver();
                }
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
                    transform.eulerAngles.z - 15f);
                
                return;
            }
            
            Vector2 Velocity = rigidbody2D.velocity;
            Velocity.x = HorizontalVelocity;
            rigidbody2D.velocity = Velocity;
            MirrorJumpState(Velocity.y);
        }
        
    }
    
    // keyboard control     in debug mode use this method
    private void KeyboardControl()
    {
        
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {
            this.HorizontalVelocity = -8f;
        }else if (!Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            this.HorizontalVelocity = 8f;
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
        
        if (HorizontalVelocity > TowardThreshold)
        {
            transform.localScale = new Vector3(MirrorLocalScale.x,MirrorLocalScale.y,MirrorLocalScale.z);
            
        }else if (HorizontalVelocity < -TowardThreshold)
        {
            transform.localScale = new Vector3(-MirrorLocalScale.x, MirrorLocalScale.y, MirrorLocalScale.z);
            
        }
    }


    
    private void MirrorJumpState(float verticalVelocity)
    {
        if (verticalVelocity > 0)
        {   
            Spring.SetActive(false);
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[0];
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SetSpringJumpState();
        }
        else
        {  
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (verticalVelocity < -6)
            {   
                SpringJump.SetActive(false);
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = Spr_Player[1];
                SetSpringState();
            }
            
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
