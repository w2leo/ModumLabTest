using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid
{
    protected Color fluidColor;
    public Color FluidColor => fluidColor;

    public Fluid()
    {
        
    }

    public Fluid(Color color)
    {
        fluidColor = color;
    }

}


