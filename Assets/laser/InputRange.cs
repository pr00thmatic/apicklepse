using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputRange {
    public float Value {
        get {
            return ((value + 1)/2) * (max-min) + min;
        }
        set {
            this.value = value;
        }
    }
    public float min;
    public float max;

    public float value;

    public float debug;

    public InputRange (float value, float min, float max) {
        this.value = value;
        this.min = min;
        this.max = max;
    }
}

