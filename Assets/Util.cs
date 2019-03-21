using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Util {
    public static bool GetLaserInput () {
        #if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButton(0) ||
            Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
        #endif

        #if UNITY_ANDROID
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
        #endif
    }

    public static Vector2 GetInputVelocity () {
        #if UNITY_EDITOR || UNITY_STANDALONE
        return new Vector2(+Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) / 3.0f +
            (Input.touchCount > 0?
             Vector2.Scale(Input.GetTouch(0).deltaPosition, new Vector2(1, -1)) :
             Vector2.zero) / 100.0f;
        #endif

        #if UNITY_ANDROID
        return Vector2.Scale(Input.GetTouch(0).deltaPosition, new Vector2(1, -1)) / 100.0f;
        #endif
    }
}
