using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectibleCounter : MonoBehaviour
{
    [SerializeField] CollectibleInfo info;


    [SerializeField] Image icon;


    [SerializeField] TextMeshProUGUI counterText;

    int count;


    private void OnEnable()
    {
        Collectible.OnCollected += IncreaseCount;
        counterText.text = count.ToString();

    }

    private void IncreaseCount(Collectible c)
    {
        if (c.Info == info)
        {
            count ++;
            counterText.text = count.ToString();
        }
    }



    private void OnValidate()
    {
        if (info != null)
        {
            if (info.Icon != null)
                icon.sprite = info.Icon;
        }
    }


    private void OnDisable()
    {
        Collectible.OnCollected -= IncreaseCount;
    }





}
