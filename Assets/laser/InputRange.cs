using UnityEngine;
using System.Collections;

namespace Laser {
    [System.Serializable]
    public class InputRange {
        public float Value {
            get {
                return ((_value + 1)/2) * (max-min) + min;
            }
            set {
                this._value = value;
            }
        }
        public float min;
        public float max;
        private float _value;

        public InputRange (float value, float min, float max) {
            this._value = value;
            this.min = min;
            this.max = max;
        }
    }
}
