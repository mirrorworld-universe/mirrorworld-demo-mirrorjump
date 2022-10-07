using UnityEngine;


public enum StairsType
{
    General,
    Disposable,
    Disappear,
    Breakage,
    Moving,
    BlackRole
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
    
    public GameController GameController;

    private float DifficultyInterval = 50f;

    public PropsFactory PropsFactory;
    
    
    
    // just test 对 brakable stairs 临时限制
    private bool Limit = false;
    
    
    

    public void GenerateStairs(Vector2 position,bool IsFirstStairs)
    {   
        Vector3 pos = new Vector3(position.x, position.y, 107.4f);
        
        StairsType stairsType = StairsType.General;
        
        
        if (!IsFirstStairs)
        {
            
            if (MirrorObject.transform.position.y < DifficultyInterval)
            {
                stairsType = OnlyGeneral();
                
            }else
            {
                stairsType = Equalization();
            }
            
        }
        
        
        InstantiationStairs(stairsType,pos);


    }
    
    

    private void InstantiationStairs(StairsType stairsType, Vector3 pos)
    {

        if (stairsType == StairsType.General)
        {    
            var tran = (UnityEngine.Object.Instantiate(GeneralStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<StairProp>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
            RandomProps(tran,GameController);

        }else if (stairsType == StairsType.Disposable)
        {
            var tran = (UnityEngine.Object.Instantiate(DisposableStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<DisposableStairs>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
            RandomProps(tran,GameController);
            
        }else if (stairsType == StairsType.Disappear)
        {
            var tran = (UnityEngine.Object.Instantiate(DisappearStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<DisappearStairs>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
            RandomProps(tran,GameController);

        }else if (stairsType == StairsType.Breakage)
        {
            var tran = (UnityEngine.Object.Instantiate(BreakageStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<BreakageStairs>().SetGameController(GameController);
            tran.transform.SetParent(StairsParent.transform);
            
            RandomProps(tran,GameController);
            
        }else if (stairsType == StairsType.Moving)
        {   
            //todo 等待进一步完善此处和难度 随机性关联的逻辑
            MovingDirection movingDirection = MovingDirection.Horizontal;
            int direct =   Random.Range(1, 10);
            if (direct >= 8)
            {
                movingDirection = MovingDirection.Vertical;
            }
            var tran = (UnityEngine.Object.Instantiate(MovingStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            tran.gameObject.GetComponent<MovingStairs>().SetGameController(GameController);
            tran.gameObject.GetComponent<MovingStairs>().SetMovingParams(movingDirection,1f,3,3);
            tran.transform.SetParent(StairsParent.transform);
            
            RandomProps(tran,GameController);
            
            
        }else if (stairsType == StairsType.BlackRole)
        {
                int rate = Random.Range(1, 10);

                if (rate >= 8)
                {
                    GenerateBlackRole(StairsParent.transform,GameController,pos);
                    
                }
                else
                {
                    
                    var tran = (UnityEngine.Object.Instantiate(GeneralStairs.gameObject)).GetComponent<Transform>();
                    tran.position = pos;
                    tran.gameObject.GetComponent<StairProp>().SetGameController(GameController);
                    tran.transform.SetParent(StairsParent.transform);
            
                    RandomProps(tran,GameController);
                    
                }
         
            
        }
        
    }
    
    
    // todo Custom rate
    //equalization
    private StairsType Equalization()
    {
        // todo : Custom random rules
        int rate = Random.Range(1, 13);
        
        if (rate <= 2)
        {
            Limit = true;
            return StairsType.General;
            
        }else if (rate <= 4)
        {    
            Limit = true;
            return StairsType.Disposable;
            
        }else if (rate <= 6)
        {   
            Limit = true;
            return StairsType.Disappear;
            
        }else if (rate <= 8)
        {   
            Limit = true;
            return StairsType.Moving;
            
        }else if (rate <= 10)
        {
            if (Limit)
            {  
                Limit = false;
                return StairsType.Breakage;
            }
            else
            {
                Limit = true;
                return StairsType.General;
            }
            
            
           
        }
        
        Limit = true;
        return StairsType.BlackRole;
        
    }
    
    private StairsType OnlyMoving()
  {
      return StairsType.Moving;
  }
    
    private StairsType OnlyGeneral()
    {
        return StairsType.General;
    }

  


  

    private void RandomProps(Transform StairsParent,GameController gameController)
    {
        
        if (MirrorObject.transform.position.y < DifficultyInterval  )
        {
            return;
        }


        int  generateRate = Random.Range(1, 11);

        if (generateRate <= 8)
        {
            return;
        }

        
        int  rate = Random.Range(1, 11);
         
        if (rate <=  2)
        {  
            GenerateSpringBoard(StairsParent, GameController);
            
        }else if (rate <= 4)
        {
           GenerateSpringProp(StairsParent, GameController);
        }
        else if(rate <= 6)
        {
            GenerateLowRocket(StairsParent, GameController);
            
        }else if (rate <= 8)
        {
            GenerateHeighRocket(StairsParent, GameController);
            
        }
        
        
        
        
    }

    private void GenerateSpringBoard(Transform StairsParent,GameController gameController)
    {
        PropsFactory.GenerateSpringBoard(StairsParent, GameController, new Vector3(0, 0.79f, 0));
        
    }
    
    private void GenerateSpringProp(Transform StairsParent,GameController gameController)
    {
        PropsFactory.GenerateSpringProp(StairsParent, GameController, new Vector3(0, 1f, 0));
    }
    
    private void GenerateLowRocket(Transform StairsParent,GameController gameController)
    {
        PropsFactory.GenerateLowRocket(StairsParent, GameController, new Vector3(0, 1f, 0));
    }
    
    private void GenerateHeighRocket(Transform StairsParent,GameController gameController)
    {
        PropsFactory.GenerateHeightRocket(StairsParent, GameController, new Vector3(0, 1.5f, 0));
    }
    
    private void GenerateBlackRole(Transform StairsParent,GameController gameController,Vector3 pos)
    {
        PropsFactory.GenerateBlackRole(StairsParent, GameController, pos);
    }
    
    public void DestroyAllStairs()
    {
        for (int i = 0; i < StairsParent.transform.childCount; i++)
        {
            Destroy( StairsParent.transform.GetChild(i).gameObject);
        }
       
    } 


}
