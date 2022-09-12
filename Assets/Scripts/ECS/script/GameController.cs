
using UnityEngine;
using Random = UnityEngine.Random;

public enum GameState
{
    Gaming,
    GamePause,
    GameOver
}

public class GameController : MonoBehaviour
{
    
    private float TheTopStairsHeight;

    private float GenerateThreshold = 10;

    public GameObject CameraObject;

    public StairsFactory StairsFactory;

    public GameObject MirrorObject;

    public MapRunSystem MapRunSystem;

    public CameraTracking CameraTracking;

    public GameMenu GameMenu;

    private Vector2 Speed = new Vector2(0, 0);

    private Vector2 SpeedZero = new Vector2(0, 0);

    private Vector2 FirstStairsPosition = new Vector2(0, -6.88f); 

    private float MaxHeight = 0;

    private GameState GameState = GameState.GameOver;
    
    private void Start()
    {
        OnGameStart();
    }

    private void FixedUpdate()
    {
        if (GetGameState() == GameState.Gaming)
        {
            if (TheTopStairsHeight - CameraObject.transform.position.y <= GenerateThreshold)
            {
                StairsFactory.GenerateStairs(GenerateStairsCoordinate(),false);
            }
        
            GetHeightScore();
        }
        
    }


    private void GetHeightScore()
    {
        if (MirrorObject.transform.position.y > MaxHeight)
        {
            MaxHeight = MirrorObject.transform.position.y;
            //
            GameMenu.SetHighScore( MaxHeight.ToString("f1"));
        }
    }


    private Vector2 GenerateStairsCoordinate()
    {
        float VerticalCoordinate = TheTopStairsHeight + RandomSpaceY();
        float HorizontalCoordinate = RandomX();
        TheTopStairsHeight = VerticalCoordinate;
        return new Vector2(HorizontalCoordinate, VerticalCoordinate);
    }
    
    private float RandomX()
    {
        Vector3 ScreenZero = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        return Random.Range(ScreenZero.x + 1.8f, -ScreenZero.x - 1.8f);
    }
    
    private float RandomSpaceY()
    {
        return  Random.Range(2f, 4f);
    }
    
    public void StartNewGame()
    {
        StairsFactory.DestroyAllStairs();
        OnGameStart();
    }
    
    // Game State
    public GameState GetGameState()
    {
        return this.GameState;
    }
   

    public void OnGamePause()
    {   
        Speed= MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().velocity;
        GameState = GameState.GamePause;
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().velocity = SpeedZero ;
    }

    public void OnGameResume()
    {   
        GameState = GameState.Gaming;
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().velocity =  Speed;
    }


    public void OnGameOver()
    {
        GameState = GameState.GameOver;
        
    }

    public void OnGameStart()
    {   
        StairsFactory.GenerateStairs(FirstStairsPosition,true);
        
        SetTransformPosition(MirrorObject.transform,new Vector3(FirstStairsPosition.x,FirstStairsPosition.y+1,107.4f));
        
        MapRunSystem.ResetMapPosition();
        
        CameraTracking.ResetCameraPosition();

        MaxHeight = 0;
        
        TheTopStairsHeight = -6.88f;
        for (int i = 0; i < 20; i++)
        {
            StairsFactory.GenerateStairs(GenerateStairsCoordinate(),false);
        }

        GameState = GameState.Gaming;

    }


    private void SetTransformPosition(Transform transform, Vector3 position)
    {
        transform.position = position;
    }
    
    

    
    
    
    
}
