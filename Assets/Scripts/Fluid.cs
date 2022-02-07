using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid
{
    private Color color;
    private float volume;
    public float Volume => volume;
    public Color Color => color;

    public Fluid()
    {

    }

    public Fluid(Color color, float volume = 0)
    {
        this.color = color;
        this.volume = volume;
    }
}


