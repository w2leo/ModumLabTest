using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableModel : MonoBehaviour
{
    [SerializeField] private RotatableObject headGameObject;
    public RotatableObject HeadGameObject => headGameObject;
}
