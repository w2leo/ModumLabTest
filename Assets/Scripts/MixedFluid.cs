using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedFluid : Fluid
{
    private Dictionary<Fluid, float> fluidsInside;

    public float CurrentVolume
    {
        get
        {
            float currentCapacity = 0;
            foreach (var item in fluidsInside)
            {
                currentCapacity += item.Value;
            }
            return currentCapacity;
        }
    }

    public Color CurrentColor
    {
        get
        {
            Color color = new Color(0, 0, 0);
            foreach (var item in fluidsInside)
            {
                color += item.Key.FluidColor * item.Value / CurrentVolume;
            }
            return color;
        }
    }

    public void AddFluid(Fluid newFluid, float volume)
    {
        if (fluidsInside.ContainsKey(newFluid))
        {
            fluidsInside[newFluid] += volume;
        }
        else
        {
            fluidsInside.Add(newFluid, volume);
        }
    }
}
