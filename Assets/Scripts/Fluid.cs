using System;

public class Fluid
{
    /// <summary>
    /// Liquid Class for mathematical description 
    /// flowSpeed - now const, but later can be variable
    /// </summary>
    private const double flowSpeed = 1.0f;

    private double CountPipeSectionArea(double pipeDiameter)
    {
        return Math.PI * Math.Pow(pipeDiameter, 2) / 4;
    }

    /// <summary>
    /// Count Liquid Consumption m3 / s. Requires pipe diameter
    /// </summary>
    /// <param name="pipeSectionArea"></param>
    /// <returns></returns>
    public double CountFluidConsumption(double pipeDiameter)
    {
        return CountPipeSectionArea(pipeDiameter) * flowSpeed;
    }
}
