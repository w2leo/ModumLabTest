using System;
using UnityEngine;

public class FluidFlow
{
    /// <summary>
    /// Liquid Class for mathematical description 
    /// flowSpeed - now const, but later can be variable
    /// </summary>
    private const float flowSpeed = 1.0f;

    private static float CountPipeSectionArea(float pipeDiameter)
    {
        return Mathf.PI * Mathf.Pow(pipeDiameter, 2) / 4;
    }

    /// <summary>
    /// Count Liquid Consumption m3 / s. Requires pipe diameter
    /// </summary>
    /// <param name="pipeSectionArea"></param>
    /// <returns></returns>
    private static float CountFluidConsumption(float pipeDiameter)
    {
        return CountPipeSectionArea(pipeDiameter) * flowSpeed;
    }

    public static Fluid PourFluidFromPipe (Fluid fluid, float pipeDiameter, float timeInSeconds)
    {
        return new Fluid(fluid.Color, CountFluidConsumption(pipeDiameter) * timeInSeconds);
    }
}
