using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsFactory : MonoBehaviour
{
    public GameObject SpringProp;
    
    public GameObject SpringBoard;

    public GameObject BlackRole;


    public Transform GenerateSpringProp(Transform StairsParent,GameController gameController,Vector3 LocalPosition)
    {  
       
        var tran = (UnityEngine.Object.Instantiate(SpringProp.gameObject)).GetComponent<Transform>();
        tran.SetParent(StairsParent);
        tran.GetComponent<SpringProp>().SetGameController(gameController);
        tran.localPosition = LocalPosition;
        return tran;
    }


    public Transform GenerateSpringBoard(Transform StairsParent,GameController gameController,Vector3 LocalPosition)
    {  
        
      
        var tran = (UnityEngine.Object.Instantiate(SpringBoard.gameObject)).GetComponent<Transform>();
        tran.SetParent(StairsParent);
        tran.GetComponent<SpringBoard>().SetGameController(gameController);
        tran.localPosition = LocalPosition;
        return tran;
    }
    
    public Transform GenerateBlackRole(Transform StairsParent,GameController gameController,Vector3 LocalPosition)
    {


      
        
        var tran = (UnityEngine.Object.Instantiate(BlackRole.gameObject)).GetComponent<Transform>();
        tran.SetParent(StairsParent);
        tran.GetComponent<BlackHole>().SetGameController(gameController);
        tran.localPosition = LocalPosition;
        return tran;
    }
    
   

}
