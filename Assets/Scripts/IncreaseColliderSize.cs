using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IncreaseColliderSize : MonoBehaviour
{

    [SerializeField] SphereCollider sCollider;

    [SerializeField] float maxRadius;

    [SerializeField] Vector2 distanceRangeToAdjust;

    [SerializeField] float safeDistanceToPlayer;

    float minRadius;


    private void Awake()
    {
        minRadius = sCollider.radius;
    }

    private void OnEnable()
    {
        CameraPosition.PositionChanged += AdjustColliderSize;

    }


    // Increase collider the further away from the camera to make clicking easier
    // override to normal size if player is close so player doesn't collide with increased collider
    private void AdjustColliderSize(Vector3 camPosition, Vector3 playerPosition)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if(distanceToPlayer < safeDistanceToPlayer )
        {
            sCollider.radius = minRadius;
            return;
        }

        float distanceToCam = Vector3.Distance(transform.position, camPosition);

        float percentOfRange = Mathf.InverseLerp(distanceRangeToAdjust.x, distanceRangeToAdjust.y, distanceToCam);
        sCollider.radius = Mathf.Lerp(minRadius, maxRadius, percentOfRange);
    }



    private void OnDisable()
    {
        CameraPosition.PositionChanged -= AdjustColliderSize;
    }





}
