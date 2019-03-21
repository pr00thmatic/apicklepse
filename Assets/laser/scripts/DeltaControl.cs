using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Laser {
    public class DeltaControl : MonoBehaviour {
        public Transform controlPoints;
        public Vector2 input;
        public bool lockPosition = false;
        public float speed;

        private Transform _rig;
        private Transform _xRot;
        private Transform _yRot;

        private Transform _up;
        private Transform _down;
        private Transform _topRight;
        private Transform _topLeft;
        private Transform _bottomRight;
        private Transform _bottomLeft;

        void Start () {
            _rig = transform.Find("rig");
            _xRot = _rig.transform.Find("x rotation");
            _yRot = _xRot.transform.Find("y rotation");

            _up = controlPoints.Find("up");
            _down = controlPoints.Find("down");
            _topRight = controlPoints.Find("top right");
            _topLeft = controlPoints.Find("top left");
            _bottomRight = controlPoints.Find("bottom right");
            _bottomLeft = controlPoints.Find("bottom left");

            input = new Vector2(0.5f, 0.5f);
        }

        void Update () {
            if (Util.GetLaserInput()) {
                float relativeSpeed = (0.2f + 0.8f * (1 - input.y)) * speed;
                input += Util.GetInputVelocity() * relativeSpeed;
                input = new Vector2(Mathf.Max(0, Mathf.Min(1, input.x)),                                    Mathf.Max(0, Mathf.Min(1, input.y)));
            }

            if (!lockPosition) {
                _rig.position = new Vector3(Mathf.Lerp(_topLeft.position.x,
                                                       _topRight.position.x, input.x),
                                            _rig.position.y, _rig.position.z);
            }

            Quaternion leftRot =
                Quaternion.Lerp(_topLeft.rotation, _bottomLeft.rotation, input.y);
            Quaternion rightRot =
                Quaternion.Lerp(_topRight.rotation, _bottomRight.rotation, input.y);

            _xRot.localRotation =
                Quaternion.Lerp(_up.rotation, _down.rotation, input.y);
            _yRot.localRotation =
                Quaternion.Lerp(leftRot, rightRot, input.x);
        }

    }
}
