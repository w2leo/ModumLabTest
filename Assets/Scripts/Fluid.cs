using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fluid
{
    protected float volume;
    protected Color color;

    public virtual float Volume => volume;

    public virtual Color Color => color;

    public Fluid()
    {
        SetColor(Color.clear);
        volume = 0;
    }

    public Fluid(Color color, float volume)
    {
        SetColor(color);
        this.volume = volume;
    }

    public abstract void AddFluid(Fluid newFluid, float volume);

    protected void SetColor(Color newColor)
    {
        color = newColor;
    }
}


