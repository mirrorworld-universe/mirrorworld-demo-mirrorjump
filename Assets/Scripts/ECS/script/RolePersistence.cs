
using UnityEngine;

public class RolePersistence : MonoBehaviour
{   
    
    public Sprite[] Common = new Sprite[5];
    
    public Sprite[] Rare = new Sprite[5];
    
    public Sprite[] Elite = new Sprite[5];
    
    public Sprite[] Legendary = new Sprite[5];
    
    public Sprite[] CommonMythical = new Sprite[5];
    
    public Sprite[] CommonJump = new Sprite[5];
    
    public Sprite[] RareJump = new Sprite[5];
    
    public Sprite[] EliteJump = new Sprite[5];
    
    public Sprite[] LegendaryJump = new Sprite[5];
    
    public Sprite[] CommonMythicalJump = new Sprite[5];

    
    
    // todo test
    public Sprite ReplacedSprite;

    public Sprite ReplacedSpriteJump;
    
    public Sprite OtherReplacedSprite;

    public Sprite OtherReplacedSpriteJump;
    

    public Sprite GetCurrentPlayer()
    {
        if (null == PlayerPrefs.GetString("CurrentPlayer"))
        {
            // use default
        }

        if ("Replace" == PlayerPrefs.GetString("CurrentPlayer"))
        {
            return ReplacedSprite;
        }
        
        if ("Other" == PlayerPrefs.GetString("CurrentPlayer"))
        {
            return OtherReplacedSprite;
        }

        return null;
    }

    public Sprite GetCurrentJumpPlayer()
    {
        if (null == PlayerPrefs.GetString("CurrentPlayer"))
        {
            // use default
        }

        if ("Replace" == PlayerPrefs.GetString("CurrentPlayer"))
        {
            return ReplacedSpriteJump;
        }
        
        if ("Other" == PlayerPrefs.GetString("CurrentPlayer"))
        {
            return OtherReplacedSpriteJump;
        }

        return null;
    }
    
    
    
}
