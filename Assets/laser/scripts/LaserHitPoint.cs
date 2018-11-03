using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserHitPoint : MonoBehaviour {
    public static float INFINITY = 100;
    public LineRenderer line;
    public Transform origin;
    public bool isInSurface = false;

    void Update () {
        line.SetPositions(new Vector3[] {origin.position,
                                         line.transform.position});
    }

    public void HitSurface () {
        isInSurface = true;
    }

    public void TendToInfinity (Vector3 direction) {
        isInSurface = false;
        transform.position = direction.normalized * INFINITY;
    }
}
