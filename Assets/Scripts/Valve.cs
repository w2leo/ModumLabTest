using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Valve : MonoBehaviour
{
    [SerializeField] private Transform handWheel;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private float currentAngle;


    private void Start()
    {
        currentAngle = 0;
        if (maxAngle == 0)
        {
            maxAngle = 360;
        }
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
        Vector3 newRotation = new Vector3(handWheel.localRotation.x, currentAngle, handWheel.localRotation.z);
        handWheel.localRotation = Quaternion.Euler(newRotation);
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
