using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Valve parentValve;

    public Valve ParentValve => parentValve;
}
