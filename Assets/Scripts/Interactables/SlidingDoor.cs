using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingDoor : Door
{
    void Update()
    {
        if (open)
        {
            gameObject.transform.DOLocalMoveZ(1.45f, 1f, false);

        }
        else
        {
            gameObject.transform.DOLocalMoveZ(0, 1f, false);
        }
    }
    public void ResetDoor()
    {
        print("Close door!");
        open = false;
    }
}
