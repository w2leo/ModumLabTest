using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedFluid : Fluid
{
    private Dictionary<Fluid, float> fluidsInside = new Dictionary<Fluid, float>();

    public MixedFluid() : base()
    {
    }

    public MixedFluid(Fluid fluid, float volume) : base()
    {
        fluidsInside.Add(fluid, volume);
    }

    public override void AddFluid(Fluid newFluid, float volume)
    {
        if (fluidsInside.ContainsKey(newFluid))
        {
            fluidsInside[newFluid] += volume;
        }
        else
        {
            fluidsInside.Add(newFluid, volume);
        }
        UpdateVolume();
        UpdateColor();
    }

    private void UpdateVolume()
    {
        float currentVolume = 0;
        foreach (var item in fluidsInside)
        {
            currentVolume += item.Value;
        }
        volume = currentVolume;
    }

    private void UpdateColor()
    {
        Color currentColor = Color.clear;
        if (Volume != 0)
        {
            foreach (var item in fluidsInside)
            {
                currentColor += item.Key.Color * item.Value / volume;
            }
        }
        SetColor(currentColor);
    }
}
