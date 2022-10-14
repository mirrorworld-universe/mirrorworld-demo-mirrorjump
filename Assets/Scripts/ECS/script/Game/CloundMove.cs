
using UnityEngine;

public class CloundMove : MonoBehaviour
{
    private float Speed = 0.001f;

    public GameController GameController;

    public void SetSpeed(float value)
    {
        Speed = value;
    }

    private void Update()
    {

        if (GameController.GetGameState() == GameState.Gaming)
        {
            if (Speed > 0)
            {
                if (transform.position.x >= 11)
                {
                    Speed = -Speed;
                    return;
                }

                transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
            }
            else
            {
                if (transform.position.x  <= 0)
                {
                    Speed = -Speed;
                    return;
                }

                transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
            
            }
        }
        
    }
    
    
    
    
}
