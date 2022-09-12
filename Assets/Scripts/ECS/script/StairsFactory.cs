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

    private float DifficultyInterval = 600f;
    

    public void GenerateStairs(Vector2 position)
    {
        Vector3 pos = new Vector3(position.x, position.y, 107.4f);
        
        StairsType stairsType = StairsType.General;

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
        
        InstantiationStairs(stairsType,pos);
        
     
    }

    private void InstantiationStairs(StairsType stairsType, Vector3 pos)
    {

        if (stairsType == StairsType.General)
        {    
            var tran = (UnityEngine.Object.Instantiate(GeneralStairs.gameObject)).GetComponent<Transform>();
            tran.position = pos;
            
        }else if (stairsType == StairsType.Disposable)
        {
            Instantiate(DisposableStairs, pos, Quaternion.identity);
            
        }else if (stairsType == StairsType.Disappear)
        {
            Instantiate(DisappearStairs, pos, Quaternion.identity);
        }else if (stairsType == StairsType.Breakage)
        {
            Instantiate(BreakageStairs, pos, Quaternion.identity);
        }else if (stairsType == StairsType.Moving)
        {
            Instantiate(MovingStairs, pos, Quaternion.identity);
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
    
    


}
