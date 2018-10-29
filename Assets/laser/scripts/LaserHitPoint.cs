using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserHitPoint : MonoBehaviour {
    public LineRenderer line;
    public GameObject origin;

    void Update () {
        line.SetPositions(new Vector3[] {origin.transform.position,
                                         line.transform.position});
    }
}
