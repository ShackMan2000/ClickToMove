using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool isMovingToTarget;

    Vector3 targetPosition;

    [SerializeField] float moveSpeed;


    void OnEnable()
    {
        Clicker.ClickedNewTarget += SetNewTarget;
    }

    void SetNewTarget(Vector3 newTargetPosition)
    {
        targetPosition = new Vector3(newTargetPosition.x, transform.position.y, newTargetPosition.z);
        isMovingToTarget = true;
    }


    void Update()
    {
        if(isMovingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if(transform.position == targetPosition )
            {
                isMovingToTarget= false;
            }
        }
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
