using UnityEngine;
using System.Collections;

namespace Laser {
    public class RayCaster : MonoBehaviour {
        public float floatingTreshold = 0.2f;
        public LaserHitPoint dot;

        void Update () {
            RaycastHit hit;
            Vector3 direction = transform.forward;

            if (Physics.Raycast(transform.position, direction,
                                out hit, Mathf.Infinity,
                                LayerMask.GetMask("laser surface", "Default"))) {
                dot.transform.position = hit.point + hit.normal * floatingTreshold;
                dot.transform.forward = hit.normal;
                dot.HitSurface();
            } else {
                dot.TendToInfinity(direction);
            }
        }
    }
}
