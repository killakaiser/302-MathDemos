using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    [Range(0, 1)]

    public float percent = 0;

    void doInterpolation()
    {
        if (pointA == null) return;
        if (pointB == null) return;

    }

}
