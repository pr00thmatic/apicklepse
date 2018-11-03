using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Laser {
    public class SimplerControl : MonoBehaviour {
        public Transform controlPoints;
        public Vector2 input;

        private Transform _rig;
        private Transform _xRot;
        private Transform _yRot;

        private Transform _up;
        private Transform _down;
        private Transform _right;
        private Transform _left;

        private float _width;
        private float _height;
        private Vector2 _top; // screen point
        private Vector2 _bottom; // screen point

        void Start () {
            _rig = transform.Find("rig");
            _xRot = _rig.transform.Find("x rotation");
            _yRot = _xRot.transform.Find("y rotation");

            _up = controlPoints.Find("up");
            _down = controlPoints.Find("down");
            _right = controlPoints.Find("right");
            _left = controlPoints.Find("left");

            _top = new Vector2(Camera.main.WorldToScreenPoint(_left.position).x,
                               Camera.main.WorldToScreenPoint(_up.position).y);
            _bottom = new Vector2(Camera.main.WorldToScreenPoint(_right.position).x,
                                  Camera.main.WorldToScreenPoint(_down.position).y);

            _width = Mathf.Abs(_top.x - _bottom.x);
            _height = Mathf.Abs(_top.y - _bottom.y);
        }

        void Update () {
            if (Input.GetMouseButton(0)) {
                input =
                    new Vector2(Mathf.Lerp(1,0,(_bottom.x - Input.mousePosition.x) / _width),
                                Mathf.Lerp(0,1,(_top.y - Input.mousePosition.y) / _height));
                _rig.position = new Vector3(Mathf.Lerp(_left.position.x, _right.position.x,
                                                       input.x),
                                            _rig.position.y, _rig.position.z);
                _xRot.localRotation =
                    Quaternion.Lerp(_up.rotation, _down.rotation, input.y);
                _yRot.localRotation =
                    Quaternion.Lerp(_left.rotation, _right.rotation, input.x);

            }
        }
    }
}
