using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ground : MonoBehaviour, IMoveTarget
{
 

    public static event Action<Vector3> GroundClicked = delegate { };

    public void Clicked(Vector3 clickedPosition) => GroundClicked(clickedPosition);
   
}
