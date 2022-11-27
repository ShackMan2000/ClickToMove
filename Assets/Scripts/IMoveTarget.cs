using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveTarget 
{
 
 
    void Clicked();
    bool MoveToCenter { get; }

    Vector3 Position { get; }
}
