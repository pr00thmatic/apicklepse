using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Laser;

public class SliderToControl : MonoBehaviour {
    public DeltaControl control;
    public Slider slider;
    public Text label;

    void Awake () {
        slider.value = control.speed;
        label.text = slider.value + "";
    }

    public void ValueChangedHandler () {
        label.text = slider.value + "";
        control.speed = slider.value;
    }
}
