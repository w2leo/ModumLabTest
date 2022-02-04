using System;

public class Fluid
{
    /// <summary>
    /// Liquid Class for mathematical description 
    /// flowSpeed - now const, but later can be variable
    /// </summary>
    private double D;
    private const double flowSpeed = 1.0f;

    private double CountPipeSectionArea(double pipeDiameter)
    {
        return Math.PI * Math.Pow(pipeDiameter, 2) / 4;
    }

    /// <summary>
    /// Count Liquid Consumption m3 / s. Requires D - pipe diameter
    /// </summary>
    /// <param name="pipeSectionArea"></param>
    /// <returns></returns>
    public double CountLiquidConsumption(double pipeDiameter)
    {
        return CountPipeSectionArea(pipeDiameter) * flowSpeed;
    }
}
