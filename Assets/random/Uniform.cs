using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Uniform : IRandomVariable {
    public float max;
    public float min;

    public Uniform (float max, float min) {
        this.max = max; this.min = min;
    }

    public float Value () {
        return Random.Range(max, min);
    }
}
