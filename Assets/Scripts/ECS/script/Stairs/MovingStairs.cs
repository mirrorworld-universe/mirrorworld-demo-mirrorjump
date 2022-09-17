
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public enum MovingDirection
{
    Horizontal,
    Vertical
}


public class MovingStairs : MonoBehaviour
{   
    
    
    
    
    public float VerticalVelocity = 10f;

    private float HeightOffset = 0.19f;

    private float RecoveryLine = 0;
    
    private GameController GameController;


    private MovingDirection MovingDirection;

    private float SlowSpeed;

    

    private Vector3 BeginningPosition;


    private float VerticalMoveDistance;

    private float SlowMoveDistance;


    private float WidthOffset = 0.8f;


    private float ReferenceX = 0f;

    private float PauseVelocity = 0;
    
    
    



    public void SetMovingParams(MovingDirection movingDirection,float slowSpeed,float verticalMoveDistance,float slowMoveDistance)
    {
        MovingDirection = movingDirection;
        SlowSpeed = slowSpeed;
        BeginningPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ReferenceX = BeginningPosition.x;
        VerticalMoveDistance = verticalMoveDistance;
        SlowMoveDistance = slowMoveDistance;
        BeginVelocityDirect();
        
    }
    
    
    // border calculate
    private float GetLeftBorder()
    {
        float TheLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        
        return TheLeft +WidthOffset;
    }


    private float GetRightBorder()
    {
        float TheLeft =  Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        
        return -TheLeft - WidthOffset;
    }


    private void BeginVelocityDirect()
    {
        if (MovingDirection == MovingDirection.Horizontal)
        {
            int beginingDirect = Random.Range(1, 2);

            if (beginingDirect == 1)
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(SlowSpeed, 0);
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-SlowSpeed, 0);
            }
        }
        else if (MovingDirection == MovingDirection.Vertical)
        {  
            int beginingDirect = Random.Range(1, 2);

            if (beginingDirect == 1)
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -SlowSpeed);   
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2*SlowSpeed);   
            }

        }
    }
    private void SpeedState()
    {
        if (MovingDirection == MovingDirection.Horizontal)
        {
            HorizontalSpeedState();
            
        }else if (MovingDirection == MovingDirection.Vertical)
        {
            VerticalSpeedState();
        }
    }


    private void HorizontalSpeedState()
    {
        if (transform.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            // to right
            if (transform.position.x >= GetRightBorder())
            {
                SpeedChange();
                return;
            }

            if (Math.Abs(transform.position.x - ReferenceX) >= SlowMoveDistance)
            {
                Accelerate();
            }
            
        }
        else
        {
            // to left
            if (transform.position.x <= GetLeftBorder())
            {
                SpeedChange();
                return;
            }

            if (Math.Abs(transform.position.x - ReferenceX) >= SlowMoveDistance)
            {
                Accelerate();
            }
        }
    }


    private void SpeedChange()
    {    
        if (transform.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-SlowSpeed, 0);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(SlowSpeed, 0);
        }

        ReferenceX = transform.position.x;
        
    }

    private void Accelerate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(2*SlowSpeed, 0);
    }
    
    
    
    // moving in the vertical direction

    private void VerticalSpeedState()
    {   
       
        if (Math.Abs(transform.position.y - BeginningPosition.y) >= VerticalMoveDistance)
        {
           
            if (transform.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(2*SlowSpeed, 0);
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-SlowSpeed, 0);
            }
            
            
        }
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


            if (MovingDirection == MovingDirection.Horizontal)
            {
                HorizontalVelocityCheckout();
            }
            else
            {
                VrticalVelocityCheckout();
            }
            
            SpeedState();
            MovingByVelocity();
            
        }else if (GameController.GetGameState() == GameState.GamePause)
        {
            
            if (MovingDirection == MovingDirection.Horizontal)
            {
               SetPauseHorizontalVelocity();
            }
            else
            {
                SetPauseVrticalVelocity();
            }
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            
        }
    }


    private void MovingByVelocity()
    {
        if (MovingDirection == MovingDirection.Horizontal)
        {
            transform.GetComponent<Rigidbody2D>().MovePosition( transform.GetComponent<Rigidbody2D>().position+Vector2.right * transform.GetComponent<Rigidbody2D>().velocity.x * Time.fixedDeltaTime);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().MovePosition( transform.GetComponent<Rigidbody2D>().position+Vector2.up * transform.GetComponent<Rigidbody2D>().velocity.y * Time.fixedDeltaTime);
        }
    }


    private void SetPauseVrticalVelocity()
    {
        PauseVelocity =  transform.GetComponent<Rigidbody2D>().velocity.y;
    }
    
    private void SetPauseHorizontalVelocity()
    {
        PauseVelocity =  transform.GetComponent<Rigidbody2D>().velocity.x;
    }

    private void HorizontalVelocityCheckout()
    {
        if (transform.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(PauseVelocity, 0);
        }   
    }


    private void VrticalVelocityCheckout()
    {
        if (transform.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, PauseVelocity);
        }   
    }
    
    
    
    public void SetGameController(GameController gameController)
    {
        GameController = gameController;
    }
   
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
    private void DestroyStairs()
    {   
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<PlatformEffector2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
         
        Destroy(gameObject);
    }
    
}