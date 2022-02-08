using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : MonoBehaviour
{
    [SerializeField] private Transform rotateWheel;
    private float minAngle;
    [SerializeField] private float maxAngle;

    public float MaxAngle => 0;
    
    public float currentAngle { get; private set; }

    private void Start()
    {
        minAngle = 0;
        SetZeroRotation();
    }

    public void RotateValve(float rotateAngle)
    {
        currentAngle += rotateAngle;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        SetRotationAngle();
    }

    private void SetRotationAngle()
    {
        Vector3 newRotation = new Vector3(rotateWheel.localRotation.x, currentAngle, rotateWheel.localRotation.z);
        rotateWheel.localRotation = Quaternion.Euler(newRotation);
    }

    public void SetZeroRotation()
    {
        currentAngle = 0;
        SetRotationAngle();
    }
}
