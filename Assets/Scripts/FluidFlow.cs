using System;
using UnityEngine;

public class FluidFlow : Fluid
{
    /// <summary>
    /// Liquid Class for mathematical description 
    /// flowSpeed - now const, but later can be variable
    /// </summary>
    private const float flowSpeed = 1.0f;

    public FluidFlow(Color color)
    {
        base.fluidColor = color;
    }

    private float CountPipeSectionArea(float pipeDiameter)
    {
        return Mathf.PI * Mathf.Pow(pipeDiameter, 2) / 4;
    }

    /// <summary>
    /// Count Liquid Consumption m3 / s. Requires pipe diameter
    /// </summary>
    /// <param name="pipeSectionArea"></param>
    /// <returns></returns>
    public float CountFluidConsumption(float pipeDiameter)
    {
        return CountPipeSectionArea(pipeDiameter) * flowSpeed;
    }
}
