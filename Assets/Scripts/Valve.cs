using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Valve : MonoBehaviour
{
    private const double minRotation = 0;
    private const double maxRotation = 720;
    private double currentRotation;

    public void RotateValve(double angle)
    {
        if (angle > 0)
        {
            RotateValveClockwise(angle);
        }
        else
        {
            RotateValveAntiClockwise(angle);
        }
    }

    public void RotateValveClockwise(double angle)
    {
        currentRotation += angle;     
    }

    public void RotateValveAntiClockwise(double angle)
    {
        currentRotation -= angle;
    }

    public void CheckRotationBounds()
    {
        throw new NotImplementedException();
    }
}
