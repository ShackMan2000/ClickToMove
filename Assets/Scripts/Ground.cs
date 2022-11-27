using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ground : MonoBehaviour, IMoveTarget
{
 


    public void Clicked() { }

    [field: SerializeField] public bool MoveToCenter { get; private set; }

    public Vector3 Position => transform.position;

}
