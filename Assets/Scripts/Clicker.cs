using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{

    Camera cam;

    Controls controls;

    public static event Action<Vector3> ClickedNewTarget = delegate { };



    private void Awake()
    {
        controls = new Controls();
        controls.Enable();  
        cam = Camera.main;
        Application.targetFrameRate = 90;
    }

    private void OnEnable()
    {
        controls.Touch.MobileClick.performed += CheckForClickableHits;
    }

 

    private void CheckForClickableHits(InputAction.CallbackContext obj)
    {
        //clicked on UI
        if(EventSystem.current.IsPointerOverGameObject())
            return;
   
        Ray ray = cam.ScreenPointToRay(controls.Touch.MobileClick.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IMoveTarget target = hit.collider.GetComponent<IMoveTarget>();

            if (target != null)
            {
                target.Clicked();
                ClickedNewTarget(hit.point);
            }

        }

    }

    //void Shoot(Vector2 clickScreenPosition)

    //{
    //    Ray ray = cam.ScreenPointToRay(clickScreenPosition);

    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        if (hit.collider.GetComponent<IMoveTarget>() != null)
    //            ClickedNewTarget(hit.point);
    //    }
    //}


    private void OnDisable()
    {
        controls.Disable();        
    }

}
