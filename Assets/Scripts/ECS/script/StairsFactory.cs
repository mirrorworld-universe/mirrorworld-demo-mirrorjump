using UnityEngine;


public enum StairsType
{
    General,
    Disposable,
    Disappear,
    Breakage,
    Moving
}
public class StairsFactory : MonoBehaviour
{

    public GameObject MirrorObject;

    public GameObject StairsParent;

    public GameObject GeneralStairs;
    
    public GameObject DisposableStairs;
    
    public GameObject DisappearStairs;
    
    public GameObject BreakageStairs;
    
    public GameObject  MovingStairs;

    public GameObject MovingStairsOther;

    public GameController GameController;

    private float DifficultyInterval = 100f;
    

    public void GenerateStairs(Vector2 position,bool IsFirstStairs)
    {   
        Vector3 pos = new Vector3(position.x, position.y, 107.4f);
        
        StairsType stairsType = StairsType.General;
        
        if (!IsFirstStairs)
        {
            if (MirrorObject.transform.position.y < DifficultyInterval)
            {
                stairsType = DifficultyLevelOne();
            
            }else if (MirrorObject.transform.position.y < 2 * DifficultyInterval)
            {
                stairsType = DifficultyLevelTwo();
            
            }else if (MirrorObject.transform.position.y < 3 * DifficultyInterval)
            {
                stairsType = DifficultyLevelThree();
            
            }else if (MirrorObject.transform.position.y < 4 * DifficultyInterval)
            {
                stairsType = DifficultyLevelFour();
            
            }else if (MirrorObject.transform.position.y < 5 * DifficultyInterval)
            {
                stairsType = DifficultyLevelFive();
            }

        }
        
        
       InstantiationStairs(stairsType,pos);
      //InstantiationStairs(StairsType.Moving,pos);
        
     
    }

    private void InstantiationStairs(StairsType stairsType, Vector3 pos)
    {

        if (stairsType == StairsType.General)
        {    
            var tran = (UnityEngine.Object.Instantiate(GeneralStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<StairProp>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);

        }else if (stairsType == StairsType.Disposable)
        {
            var tran = (UnityEngine.Object.Instantiate(DisposableStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<DisposableStairs>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
        }else if (stairsType == StairsType.Disappear)
        {
            var tran = (UnityEngine.Object.Instantiate(DisappearStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<DisappearStairs>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);

        }else if (stairsType == StairsType.Breakage)
        {
            var tran = (UnityEngine.Object.Instantiate(BreakageStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<StairProp>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
        }else if (stairsType == StairsType.Moving)
        {   
            //todo 等待进一步完善此处和难度 随机性关联的逻辑
            int type =   Random.Range(1, 10);
            MovingDirection movingDirection = MovingDirection.Horizontal;

            if (type <=5)
            {   
                int direct =   Random.Range(1, 10);
                if (direct <= 5)
                {
                    movingDirection = MovingDirection.Vertical;
                }
                var tran = (UnityEngine.Object.Instantiate(MovingStairs.gameObject)).GetComponent<Transform>();
                tran.position = pos;
                tran.gameObject.GetComponent<MovingStairs>().SetGameController(GameController);
                tran.gameObject.GetComponent<MovingStairs>().SetMovingParams(movingDirection,0.005f,3,1);
                tran.transform.SetParent(StairsParent.transform);
            }
            else
            {   
                int direct =   Random.Range(1, 10);
                if (direct <= 5)
                {
                    movingDirection = MovingDirection.Vertical;
                }
                var tran = (UnityEngine.Object.Instantiate(MovingStairsOther.gameObject)).GetComponent<Transform>();
                tran.position = pos;
                tran.gameObject.GetComponent<MovingStairs>().SetGameController(GameController);
                tran.gameObject.GetComponent<MovingStairs>().SetMovingParams(movingDirection,0.005f,3,1);
                tran.transform.SetParent(StairsParent.transform);
            }
           
            
        }
        
    }

   

    private StairsType DifficultyLevelOne()
    {    
        //100% General
        return StairsType.General;
    }
    
    private StairsType DifficultyLevelTwo()
    {
        // 60% General  40%  Disposable
        int rate = Random.Range(1, 10);

        if (rate <= 6)
        {
            return StairsType.General;
        }

        return StairsType.Disposable;
    }
    
    private StairsType DifficultyLevelThree()
    {
        // 40% General  30%  Disposable 30% Disappear
        int rate = Random.Range(1, 10);

        if (rate <= 4)
        {
            return StairsType.General;
        }else if (rate <= 7)
        {
            return StairsType.Disposable;
        }

        return StairsType.Disappear;
    }
    
    private StairsType DifficultyLevelFour()
    {
        // 30% General  30%  Disposable 20% Disappear 20% Moving
        int rate = Random.Range(1, 10);

        if (rate <= 3)
        {
            return StairsType.General;
            
        }else if (rate <= 6)
        {
            return StairsType.Disposable;
            
        }else if (rate <= 8)
        {
            return StairsType.Disappear;
        }

        return StairsType.Moving;
    }
    
    private StairsType DifficultyLevelFive()
    {
        // 10% General  30%  Disposable 30% Disappear 30% Moving
        int rate = Random.Range(1, 10);

        if (rate <= 1)
        {
            return StairsType.General;
            
        }else if (rate <= 4)
        {
            return StairsType.Disposable;
            
        }else if (rate <= 7)
        {
            return StairsType.Disappear;
        }

        return StairsType.Moving;
    }


    public void DestroyAllStairs()
    {
        for (int i = 0; i < StairsParent.transform.childCount; i++)
        {
           Destroy( StairsParent.transform.GetChild(i).gameObject);
        }
       
    }
    
    


}
