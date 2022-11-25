using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{


    [SerializeField] InputAction mouseClick;


    Camera cam;


    public static event Action<Vector3> ClickedNewTarget = delegate { };


    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += CheckForClickableHits;

        cam = Camera.main;
    }

    private void CheckForClickableHits(InputAction.CallbackContext obj)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.GetComponent<IMoveTarget>() != null)
                ClickedNewTarget(hit.point);
        }

    }
}
