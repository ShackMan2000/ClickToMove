using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] float checkToAdjustTime = 0.2f;

    [SerializeField] Transform player;

    float counter;



    public static event Action<Vector3, Vector3> PositionChanged = delegate { };



    void Awake()
    {
        counter = checkToAdjustTime;
    }

    void Update()
    {
        counter -= Time.deltaTime;

        if (counter < 0f)
        {
            counter = checkToAdjustTime;

                PositionChanged(transform.position, player.position);
            
        }
    }
}








