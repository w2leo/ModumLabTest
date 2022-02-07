using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
 public class MixedFluid : Fluid
{
    private Dictionary<Fluid, float> fluidsInside = new Dictionary<Fluid, float>();
    [SerializeField] public float CurrentVolume
    {
        get
        {
            float currentVolume = 0;
            foreach (var item in fluidsInside)
            {
                currentVolume += item.Value;
            }
            return currentVolume;
        }
    }
    [SerializeField] public Color CurrentColor
    {
        get
        {
            Color color = new Color(0,0,0);
            if (CurrentVolume != 0)
            {
                foreach (var item in fluidsInside)
                {
                    color += item.Key.Color * item.Value / CurrentVolume;
                }
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
