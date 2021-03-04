using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingDoor : Door
{
    public GameObject left;
    public GameObject right;
    void Update()
    {
        if (open)
        {
            left.transform.DOLocalMoveZ(1.45f, 1f, false);
            right.transform.DOLocalMoveZ(-2.90f, 1f, false);
        }
        else
        {
            left.transform.DOLocalMoveZ(0, 1f, false);
            right.transform.DOLocalMoveZ(-1.45f, 1f, false);
        }
    }
    public void ResetDoor()
    {
        open = false;
    }
}
