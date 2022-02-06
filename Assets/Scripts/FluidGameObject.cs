using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FluidGameObject : MonoBehaviour
{
    [SerializeField] private Cistern cistern;
    private float diameter;
    [SerializeField] private MixedFluid fluidInside;
    private MeshRenderer meshRenderer;
    private float maxVolume;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        fluidInside = new MixedFluid();
        maxVolume = cistern.Capacity;
        diameter = cistern.Diameter;
        SetVolume();
    }

    private void Update()
    {
        SetColor();
    }

    private void SetColor()
    {
        meshRenderer.material.color = fluidInside.CurrentColor;
    }

    private void SetVolume()
    {
        Vector3 newScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        newScale.y = fluidInside.CurrentVolume / maxVolume;
        transform.localScale = newScale;
    }

    private float CountCylinderHeight(float volume, float diameter)
    {
        float radius = diameter / 2;
        return volume / (Mathf.PI * Mathf.Pow(radius, 2));
    }

    public void AddFluidToGameObject(Fluid newFluid, float volume)
    {
        fluidInside.AddFluid(newFluid, volume);
        SetVolume();
    }
}
