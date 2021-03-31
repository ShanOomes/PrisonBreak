using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerPos;
    Vector3 dir;
    // Update is called once per frame
    void Update()
    {
        dir.z = playerPos.eulerAngles.y;
        transform.localEulerAngles = dir;
    }
}
