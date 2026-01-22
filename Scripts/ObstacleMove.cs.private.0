using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame 
    void Update()
    {
        transform.position = initialPosition + transform.rotation * Vector3.forward * Mathf.Sin(Time.time*2.5f) * 10f;
    }
}
