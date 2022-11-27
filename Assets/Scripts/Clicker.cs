using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{

    Camera cam;

    Controls controls;

    public static event Action<Vector3> ClickedNewTarget = delegate { };

    PointerEventData pointerData;

    [SerializeField] GraphicRaycaster raycaster;

    private void Awake()
    {
        controls = new Controls();
        controls.Enable();
        cam = Camera.main;

        pointerData = new PointerEventData(null);
    }

    private void OnEnable()
    {
        controls.Touch.MobileClick.performed += CheckForClickableHits;
    }



    private void CheckForClickableHits(InputAction.CallbackContext obj)
    {
        // check if input is over UI element 
        // pointer over UI only works with releasing finger, so doing this workaround

        pointerData.position = controls.Touch.MobileClick.ReadValue<Vector2>();

        List<RaycastResult> raycastResults = new List<RaycastResult>();

        raycaster.Raycast(pointerData, raycastResults);

        if (raycastResults.Count > 0)
            return;


        Ray ray = cam.ScreenPointToRay(controls.Touch.MobileClick.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IMoveTarget target = hit.collider.GetComponent<IMoveTarget>();

            if (target != null)
            {
                target.Clicked();
                if (target.MoveToCenter)
                    ClickedNewTarget(target.Position);
                else
                    ClickedNewTarget(hit.point);
            }

        }

    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
