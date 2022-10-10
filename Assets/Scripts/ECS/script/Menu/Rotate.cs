using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // 每次旋转360度的多少份
    [SerializeField] private int rotateData = 68;
    private Vector3 eulerAngle;

    // 多久旋转一次
    [SerializeField] private float changeTime = 0.5f;

    [SerializeField] private float timeRecorder;
    private void FixedUpdate()
    {
        timeRecorder += Time.deltaTime;
        if(timeRecorder > changeTime)
        {
            timeRecorder = 0;
            eulerAngle = transform.eulerAngles;
            eulerAngle.z += 360 / rotateData;
            transform.eulerAngles = eulerAngle;
        }
    }
}
