using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //实现一个在90度范围内来回旋转的效果

        transform.rotation = Quaternion.Euler(0, 0, 45 * Mathf.Sin(Time.time * 4));
    }
}
