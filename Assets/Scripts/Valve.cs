using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Valve : MonoBehaviour
{
    [SerializeField] private Transform sterringWheel;
    private const float minAngle = 0;
    private const float maxAngle = 720;
    private float currentAngle;


    private void Start()
    {
        currentAngle = 0;
        SetRotationAngle();
    }
    public void RotateValve(float rotateAngle)
    {
        currentAngle += rotateAngle;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        SetRotationAngle();
    }

    private void SetRotationAngle()
    {
        Vector3 newRotation = new Vector3(sterringWheel.localRotation.x, currentAngle, sterringWheel.localRotation.z);
        sterringWheel.localRotation = Quaternion.Euler(newRotation);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateValve(-180 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateValve(180 * Time.deltaTime);
        }
    }
}
