using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cistern : CisternSize
{
    [SerializeField] private Fluid fluidInside;
    [SerializeField] private Transform fluidGameObject;
    private MeshRenderer fluidMeshRenderer;

    public void Start()
    {
        if (!fluidGameObject.TryGetComponent<MeshRenderer>(out fluidMeshRenderer))
            throw new NullReferenceException();

        fluidInside = new MixedFluid();
        SetFluidInsideVolume();
        SetFluidInsideColor();
    }

    private void SetFluidInsideColor()
    {
        fluidMeshRenderer.material.color = fluidInside.Color;
    }

    private void SetFluidInsideVolume()
    {
        Vector3 newScale = new Vector3(fluidGameObject.localScale.x, 0, fluidGameObject.localScale.z);
        newScale.y = fluidInside.Volume / Capacity;
        fluidGameObject.localScale = newScale;
    }

    public bool AddFluidToCistern(Fluid newFluid, float volume)
    {
        if (fluidInside.Volume < Capacity)
        {
            fluidInside.AddFluid(newFluid, volume);
            SetFluidInsideVolume();
            SetFluidInsideColor();
            return true;
        }
        else
        {
            Debug.Log("Cistern if full");
            return false;
        }
    }
}
