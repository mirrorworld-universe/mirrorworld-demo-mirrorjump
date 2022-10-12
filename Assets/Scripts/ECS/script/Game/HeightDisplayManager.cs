﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightDisplayManager : Singleton<HeightDisplayManager>
{
    // 根据传入高度，计算刻度线时的上下各自偏移量
    private float yOffset = 10;
    private float xPos;
    private float criticalHeight;
    private float initY;
    // 刻度线显示距离
    private long markDistance = 50;
    private long firstHeight = 201;

    public void GenerateFirst(float height)
    {
        // 数据初始化
        initY = height;
        yOffset *= GlobalDef.heightCoefficient;

        // 计算数字水平位置
        var mapPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        xPos = mapPos.x + 0.2f;
        // 前firstHeight高度，每markDistance显示一格
        criticalHeight = height + firstHeight;

        GameObject obj = ObjectPooler.Instance.SpawnFromPool("HeightNumber", new Vector3(xPos, height, 0), Quaternion.identity, -1);
        obj.GetComponent<HeightNumber>().Setup((long)height);
    }
    // 根据当前地块高度，生成高度线
    public void GenerateHeightNumber(float height)
    {
        var minH = height - yOffset;
        var maxH = height + yOffset;

        var rest = minH % markDistance;
        long mark = (long)(minH - rest) + markDistance;

        while(mark < maxH)
        {
            bool isHigherThanInit = mark > initY;
            bool isLowerThanCriticalHeight = mark < criticalHeight;
            bool isHigherThanCriticalHeightCanShow = mark > criticalHeight && mark % 100 == 0;
            if (isHigherThanInit && (isLowerThanCriticalHeight || isHigherThanCriticalHeightCanShow) ) 
            {
                GameObject obj = ObjectPooler.Instance.SpawnFromPool("HeightNumber", new Vector3(xPos, mark/ GlobalDef.heightCoefficient, 0), Quaternion.identity, -1);
                obj.GetComponent<HeightNumber>().Setup(mark);
            }

            mark += markDistance;
        }
        return;
    }
}