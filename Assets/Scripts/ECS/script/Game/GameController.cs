
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

    private Vector2 FirstStairsPosition = new Vector2(0, -3f); 

    private long MaxHeight = 0;

    private GameState GameState = GameState.GameOver;
    
    
    // role change
    public RolePersistence RolePersistence;
    
    
    
    private void Start()
    {
        OnGameStart();
    }

    private void FixedUpdate()
    {
        if (GetGameState() == GameState.Gaming)
        {   
           
            while (TheTopStairsHeight - CameraObject.transform.position.y <= GenerateThreshold)
            {
                StairsFactory.GenerateStairs(GenerateStairsCoordinate(),false);
            }
        
            GetHeightScore();
        }
        
    }

    public long GetMaxHeight()
    {
        return MaxHeight;
    }


    private void GetHeightScore()
    {
        if (MirrorObject.transform.position.y* GlobalDef.heightCoefficient > MaxHeight)
        {
            MaxHeight = (long)MirrorObject.transform.position.y * GlobalDef.heightCoefficient;

            GameMenu.SetHighScore(MaxHeight.ToString());
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
        return Random.Range(ScreenZero.x + 1f, -ScreenZero.x - 1f);
    }
    
    private float RandomSpaceY()
    {
        return  Random.Range(1f,1.3f);
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
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        GameState = GameState.GamePause;
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().velocity = SpeedZero ;
    }

    public void OnGameResume()
    {   
        GameState = GameState.Gaming;
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().velocity =  Speed;
        MirrorObject.transform.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
    }


    public void OnGameOver()
    {
        GameState = GameState.GameOver;
        
    }

    public void OnGameStart()
    {   
        MirrorJump mj = MirrorObject.GetComponent<MirrorJump>();
        
        if (null == PlayerPrefs.GetString("CurrentRole") || null == PlayerPrefs.GetString("CurrentRarity"))
        {
            mj.Spr_Player[1] = RolePersistence.GetDefaultRole();
            mj.Spr_Player[0] = RolePersistence.GetDefaultRoleJump();
            mj.RefreshSprite();
        }
        else
        {
            mj.Spr_Player[1] =
                RolePersistence.GetRoleImage(PlayerPrefs.GetString("CurrentRole"),
                    PlayerPrefs.GetString("CurrentRarity"));

            mj.Spr_Player[0] =
                RolePersistence.GetRoleImageJump(PlayerPrefs.GetString("CurrentRole"),
                    PlayerPrefs.GetString("CurrentRarity"));

            mj.RefreshSprite();
        }

        Vector2 initPos = FirstStairsPosition;
        long initScore = 0;
        if (PlayerPrefs.GetInt(GlobalDef.hasInitPosY) == 1)
        {
            initScore = long.Parse(PlayerPrefs.GetString(GlobalDef.maxScore))/2;
            PlayerPrefs.SetInt(GlobalDef.hasInitPosY, 0);
        }
        var initY = initScore / GlobalDef.heightCoefficient;
        initPos.y += initY;
        
        MirrorObject.transform.eulerAngles = new Vector3(0,0,0);
        MirrorObject.transform.localScale = new Vector3(0.28f,0.28f,0.28f);
        MirrorObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        MirrorObject.transform.GetComponent<MirrorJump>().Setup();
        SetTransformPosition(MirrorObject.transform,new Vector3(initPos.x, initPos.y+2f,107.4f));
        
        StairsFactory.GenerateStairs(initPos, true);

        HeightDisplayManager.Instance.GenerateFirst(initScore);

        MapRunSystem.ResetMapPosition(initY);
        
        CameraTracking.ResetCameraPosition(initY);

        MaxHeight = initScore;
        GameMenu.SetHighScore(MaxHeight.ToString());

        TheTopStairsHeight = initPos.y;
      
        GameState = GameState.Gaming;
        
        GameMenu.CloseGameOverWindow();
    }


    private void SetTransformPosition(Transform transform, Vector3 position)
    {
        transform.position = position;
    }
    
    

    
    
    
    
}
