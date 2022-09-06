using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntrance : MonoBehaviour
{

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        GameWorld.Instance.OnFixUpdate();
    }

    private void FixedUpdate()
    {
        
    }
}
