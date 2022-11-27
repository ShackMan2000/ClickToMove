using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool isMovingToTarget;

    Vector3 targetPosition;

    [SerializeField] float currentMoveSpeed;


    [SerializeField] Vector2 speedRange;

    void OnEnable()
    {
        Clicker.ClickedNewTarget += SetNewTarget;
        currentMoveSpeed = speedRange.x + ((speedRange.y - speedRange.x) / 2f);
    }

    void SetNewTarget(Vector3 newTargetPosition)
    {
        targetPosition = new Vector3(newTargetPosition.x, transform.position.y, newTargetPosition.z);
        isMovingToTarget = true;
        transform.LookAt(targetPosition);
    }


    void Update()
    {
        if(isMovingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);
            if(transform.position == targetPosition )
            {
                isMovingToTarget= false;
            }
        }
    }



    public void ChangeMoveSpeed(float changeBy)
    {
        currentMoveSpeed = Mathf.Clamp(currentMoveSpeed + changeBy, speedRange.x, speedRange.y);

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
