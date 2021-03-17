using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HingeDoor : Door
{

    void Update()
    {
        if (open)
        {
            gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 3.0f);
        }
        else
        {
            gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 90), 3.0f);
        }
    }
}
