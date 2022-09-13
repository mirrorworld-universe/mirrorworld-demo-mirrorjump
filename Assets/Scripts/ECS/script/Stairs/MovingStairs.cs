
using UnityEngine;



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


    private float WidthOffset = 0.8f;
    



    public void SetMovingParams(MovingDirection movingDirection,float slowSpeed,float verticalMoveDistance)
    {
        MovingDirection = movingDirection;
        SlowSpeed = slowSpeed;
        BeginningPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        VerticalMoveDistance = verticalMoveDistance;
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
