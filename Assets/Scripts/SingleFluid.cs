using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFluid : Fluid
{
    public SingleFluid() : base()
    { 
    }

    public SingleFluid(Color color, float volume) : base(color, volume)
    {
    }

    public override void AddFluid(Fluid newFluid, float volume)
    {
        if (newFluid.Color == Color)
        {
            volume += volume;
        }
    }
}
