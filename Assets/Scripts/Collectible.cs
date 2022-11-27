using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshRenderer))]
public class Collectible : MonoBehaviour, IMoveTarget
{
   
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] Vector3 expandScaleOnClick;
    [SerializeField] float scaleOnClickDuration;

    

    [field : SerializeField] public CollectibleInfo Info { get; private set; }

    public static event Action<Collectible> OnCollected = delegate { };


    bool isScaling;
    Vector3 originalScale;
    


    private void Awake()
    {
        originalScale= transform.localScale;
    }

    public void InjectInfo(CollectibleInfo injectedInfo)
    {
        Info= injectedInfo;
        meshRenderer.material = Info.Material;
        gameObject.name = Info.Name + "Collectible";
    }


    public void Clicked()
    {
        if (!isScaling)
            StartCoroutine(ScaleRoutine());
    }

    public void PickUp()
    {
        OnCollected(this);
        gameObject.SetActive(false);
    }



    private void OnValidate()
    {
        if (Info != null)
        {
            meshRenderer.material = Info.Material;            
        }
    }




    IEnumerator ScaleRoutine()
    {
        isScaling = true;

        float progress = 0f;

        

        while(progress < 1f)
        {
            progress+= Time.deltaTime / scaleOnClickDuration;
            transform.localScale = Vector3.Lerp(transform.localScale, expandScaleOnClick, progress);


            Debug.Log(progress);
            yield return null;
        }


        progress= 0f;

        while (progress < 1f)
        {
            transform.localScale = Vector3.Lerp(expandScaleOnClick, originalScale, progress);
            yield return null;
        }


        isScaling= false;
    }

}
