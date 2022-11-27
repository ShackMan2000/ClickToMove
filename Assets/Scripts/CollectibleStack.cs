using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CollectibleStack
{
    /// <summary>
    /// workaround to show dictionary like feature in the editor
    /// </summary>

    [field : SerializeField] public CollectibleInfo Info { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }

    

}
