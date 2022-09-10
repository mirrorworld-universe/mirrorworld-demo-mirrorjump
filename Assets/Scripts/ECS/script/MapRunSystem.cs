using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BackPanelTag
{
    Bottom,
    Middle,
    Top
}
public class MapRunSystem : MonoBehaviour
{

    public GameObject ButtomBack;
    
    public GameObject MiddleBack;
    
    public GameObject TopBack;
    
    private BackPanelTag backPanelTag = BackPanelTag.Bottom;
    
    private int TagIndex = 0;

    private float UnitDistance = 19.12f;
    
    public void MovingMap()
    {   
        SetTagByIndex();

        if (backPanelTag == BackPanelTag.Bottom)
        {
            SetRotationAndPosition(ButtomBack);
            
        }else if (backPanelTag == BackPanelTag.Middle)
        {
            SetRotationAndPosition(MiddleBack);
        }else if (backPanelTag == BackPanelTag.Top)
        {
            SetRotationAndPosition(TopBack);
        }

        TagIndex++;

    }
    
    private void SetTagByIndex()
    {
        if (TagIndex == 3)
        {
            TagIndex = 0;
        }

        if (TagIndex == 0)
        {
            backPanelTag = BackPanelTag.Bottom;
            
        }else if (TagIndex == 1)
        {
            backPanelTag = BackPanelTag.Middle;
        }else if (TagIndex == 2)
        {
            backPanelTag = BackPanelTag.Top;
        }
        
    }

    private void SetRotationAndPosition(GameObject gameObject)
    {
        float RotationZ = 0f;
        float PositionY = gameObject.transform.position.y + 3 * UnitDistance;
        Vector3 Position = new Vector3(gameObject.transform.position.x, PositionY,
            gameObject.transform.position.z);
        
        
        if (gameObject.transform.localRotation.z >= 180)
        { 
            RotationZ = gameObject.transform.localEulerAngles.z -180;
            Vector3 Rotation = new Vector3(gameObject.transform.localEulerAngles.x,
                gameObject.transform.localEulerAngles.y, RotationZ);
            
            gameObject.transform.localEulerAngles = Rotation;
        }
        else
        {
            RotationZ = gameObject.transform.localEulerAngles.z +180;
            Vector3 Rotation = new Vector3(gameObject.transform.localEulerAngles.x,
                gameObject.transform.localEulerAngles.y, RotationZ);
            
            gameObject.transform.localEulerAngles = Rotation;
            
        }

        gameObject.transform.position = Position;
        
    }
    
   
        
    
}
