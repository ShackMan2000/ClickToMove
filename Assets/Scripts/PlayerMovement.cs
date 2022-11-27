using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool isMovingToTarget;

    Vector3 targetPosition;

   public float CurrentMoveSpeed { get; private set; }



    [field: SerializeField] public Vector2 SpeedRange { get; private set; }


    private void Awake()
    {
        CurrentMoveSpeed = SpeedRange.x + ((SpeedRange.y - SpeedRange.x) / 2f);        
    }

    void OnEnable()
    {
        Clicker.ClickedNewTarget += SetNewTarget;
    }

    void SetNewTarget(Vector3 newTargetPosition)
    {
        targetPosition = new Vector3(newTargetPosition.x, transform.position.y, newTargetPosition.z);
        isMovingToTarget = true;
        transform.LookAt(targetPosition);
    }


    void Update()
    {
        if (isMovingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, CurrentMoveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMovingToTarget = false;
            }
        }
    }



    public void SetMoveSpeed(float newSpeed)
    {
        CurrentMoveSpeed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectible = other.GetComponent<Collectible>();
        collectible?.PickUp();

    }




    void OnDisable()
    {
        Clicker.ClickedNewTarget -= SetNewTarget;
    }
}
