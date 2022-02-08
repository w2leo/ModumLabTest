using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CisternSize : MonoBehaviour
{
    [SerializeField] private Transform extremeDotA;
    [SerializeField] private Transform extremeDotB;
    [SerializeField] private Transform extremeDotC;

    public float Height => Vector3.Distance(extremeDotB.position, extremeDotC.position);
    public float Diameter => Vector3.Distance(extremeDotA.position, extremeDotB.position);
    public float Capacity => Mathf.PI * Mathf.Pow(Diameter / 2, 2) * Height;
}
