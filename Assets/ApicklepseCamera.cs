using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApicklepseCamera : MonoBehaviour {
    public float maxSpeed = 3;
    public float acceleration = 1;

    public float _speed = 0;

    void Update () {
        _speed += acceleration * Time.deltaTime;
        transform.position += new Vector3(0, 0, 1) * _speed * Time.deltaTime;
    }
}
