using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(RotatableObject))]
public class Valve : MonoBehaviour
{
    [SerializeField] private Material fluidMaterial;
    [SerializeField] private float pipeDiametr;
    [SerializeField] private Cistern destinationCistern;
    
    private Fluid fluidInPipe;
    private RotatableObject wheel;
    
    private void Start()
    {
        fluidInPipe = new SingleFluid(fluidMaterial.color, 0);
        wheel = GetComponent<RotatableObject>();
    }

    private void Update()
    {
        if (wheel.currentAngle > 0)
        {
            float fluidVolumeInSecond = FluidFlow.CountFluidConsumption(pipeDiametr);
            bool cisternStatus = destinationCistern.AddFluidToCistern(fluidInPipe, fluidVolumeInSecond * Time.deltaTime);
            if (!cisternStatus)
            {
                CloseValve();
            }
        }
    }

    private void CloseValve()
    {
        wheel.SetZeroRotation();
    }


}
