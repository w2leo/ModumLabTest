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
    [SerializeField] private Color fluidColor;
    [SerializeField] private float pipeDiametr;
    [SerializeField] private FluidGameObject mixedFluid;
    private float currentAngle;
    private FluidFlow fluid;

    private void Start()
    {
        currentAngle = 0;
        if (maxAngle == 0)
        {
            maxAngle = 360;
        }
        SetRotationAngle();

        fluid = new FluidFlow(fluidColor);
    }

    private void Update()
    {
        if (currentAngle > 0)
        {
            float fluidVolume = fluid.CountFluidConsumption(pipeDiametr) * Time.deltaTime;
            mixedFluid.AddFluidToGameObject(fluid, fluidVolume);
        }
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
}
