using UnityEngine;
using System.Collections;

namespace Laser {
    public class Control : MonoBehaviour {
        public GameObject center;
        public GameObject circunferencePoint;

        public InputRange tilt = new InputRange(0, 12, 55, TypeOfRange.UNSIGNED);
        public InputRange direction = new InputRange(0, -60, 60);

        public float _radius;
        private Vector3 _center;

        void Start () {
            _radius =
                (Camera.main.WorldToScreenPoint(center.transform.position) -
                 Camera.main.WorldToScreenPoint(circunferencePoint.transform.position)).
                 magnitude;

            _center = Camera.main.WorldToScreenPoint(center.transform.position);
        }

        void Update () {
            if (Input.GetMouseButton(0)) {
                Vector2 mousePos = Input.mousePosition;
                direction.Value = _SignedProportion(mousePos.x - _center.x);
                tilt.Value = -_UnsignedProportion(_center.y - mousePos.y);
            }

            transform.rotation = Quaternion.Euler(tilt.Value, direction.Value, 0);
        }

        private float _UnsignedProportion (float value) {
            return Mathf.Min(Mathf.Max(-1, value / _radius), 0);
        }

        private float _SignedProportion (float value) {
            if (value < -_radius || value > _radius) {
                return 1 * Mathf.Sign(value);
            }

            return value / _radius;
        }
    }
}
