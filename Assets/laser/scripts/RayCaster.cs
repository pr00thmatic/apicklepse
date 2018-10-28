using UnityEngine;
using System.Collections;

namespace Laser {
    public class RayCaster : MonoBehaviour {
        public float floatingTreshold = 0.2f;
        public GameObject dot;

        private Control _control;

        void Start () {
            _control = GetComponent<Control>();
        }

        void Update () {
            RaycastHit hit;
            Vector3 direction = _control.transform.forward;

            if (Physics.Raycast(transform.position, direction,
                                out hit, Mathf.Infinity,
                                LayerMask.GetMask("laser surface", "Default"))) {
                dot.transform.position = hit.point + hit.normal * floatingTreshold;
                dot.transform.forward = hit.normal;
            }
        }
    }
}
