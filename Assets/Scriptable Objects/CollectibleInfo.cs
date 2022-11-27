using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CollectibleInfo : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }

    [field: SerializeField] public GameObject PickUpEffect { get; private set; }

    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public Material Material { get; private set; }

}
