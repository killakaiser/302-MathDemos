using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitDemo : MonoBehaviour
{
    public float timeMultiplier = 2;
    public float timeOffset = 0;

    public Transform orbitCenter;

    public float radius = 10;

    public int pathResolution = 256;

    private LineRenderer path;

    void Start()
    {
        path = GetComponent<LineRenderer>();

        path.loop = true;
        path.useWorldSpace = true;

        UpdateOrbitPath();
        

    }

    void Update()
    {
        if (!orbitCenter) return;

        float x = radius * Mathf.Cos(Time.time * timeMultiplier + timeOffset);
        float z = radius * Mathf.Sin(Time.time * timeMultiplier + timeOffset);

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;

        if (orbitCenter.hasChanged) UpdateOrbitPath();
    }

    void UpdateOrbitPath()
    {
        if (!orbitCenter) return;

        float radsPerCircle = 2 * Mathf.PI;



        Vector3[] pts = new Vector3[pathResolution];

        for (int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * 2 * radsPerCircle/pathResolution);
            float z = radius * Mathf.Sin(i * 2 * radsPerCircle/pathResolution);

            pts[i] = new Vector3(x, 0, z) + orbitCenter.position;
        }
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }
}
