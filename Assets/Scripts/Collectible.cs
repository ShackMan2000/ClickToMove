using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshRenderer))]
public class Collectible : MonoBehaviour, IMoveTarget
{


    [SerializeField] CollectibleInfo info;

    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] int amount;


    public static event Action<CollectibleInfo> OnCollected = delegate { };

    public void Clicked(Vector3 clickPosition)
    {
    }

    public virtual void PickUp()
    {
        OnCollected(info);

        gameObject.SetActive(false);
    }



    private void OnValidate()
    {
        if(info!= null)
        {
            meshRenderer.material = info.Material;
        }
    }




}
