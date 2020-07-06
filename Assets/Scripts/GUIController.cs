using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Slider sliderHorizontal;
    public Slider sliderVertical;

    public Button buttonFire;

    public Action<float> horizontalAngle;
    public Action<float> verticalAngle;
    public Action shot;

    void changeHorizontal(float angle)
    {
        horizontalAngle?.Invoke(angle);
    }

    void changeVertical(float angle)
    {
        verticalAngle?.Invoke(angle);
    }

    void sendShotMessage() {
        shot?.Invoke();
    }

    void Start()
    {
        sliderHorizontal.onValueChanged.AddListener(changeHorizontal);
        sliderVertical.onValueChanged.AddListener(changeVertical);
        buttonFire.onClick.AddListener(sendShotMessage);
    }
}
