using UnityEngine;
using System.Collections;

namespace Laser {
    public enum TypeOfRange {
        UNSIGNED,
        SIGNED
    }

    [System.Serializable]
    public class InputRange {
        public float Value {
            get {
                if (typeOfRange == TypeOfRange.SIGNED) {
                    return ((_value + 1)/2) * (max-min) + min;
                }

                return _value * (max - min) + min;
            }
            set {
                this._value = value;
            }
        }
        public float min;
        public float max;
        public TypeOfRange typeOfRange = TypeOfRange.SIGNED;

        public float _value;

        public InputRange (float value, float min, float max, TypeOfRange type = TypeOfRange.SIGNED) {
            this._value = value;
            this.min = min;
            this.max = max;
            this.typeOfRange = type;
        }
    }
}
