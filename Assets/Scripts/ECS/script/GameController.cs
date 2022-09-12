
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    
    private float TheTopStairsHeight;

    private float GenerateThreshold = 10;

    public GameObject CameraObject;

    public StairsFactory StairsFactory;
    

    private void Start()
    {
        TheTopStairsHeight = -6.88f;
        for (int i = 0; i < 20; i++)
        {
            StairsFactory.GenerateStairs(GenerateStairsCoordinate());
        }
        
    }

    private void FixedUpdate()
    {
        if (TheTopStairsHeight - CameraObject.transform.position.y <= GenerateThreshold)
        {
            StairsFactory.GenerateStairs(GenerateStairsCoordinate());
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
        return  Random.Range(1f, 4f);
    }
    
    
    
    
}
