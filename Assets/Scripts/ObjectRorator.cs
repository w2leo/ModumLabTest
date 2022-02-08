using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRorator : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private RotatableObject takenObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryTakeObject(out takenObject);
        }

        float rotationAngle = CheckRotationDirection();
        if (Input.GetMouseButton(0) && takenObject != null && rotationAngle!=0)
        {
            takenObject.RotateValve(rotationAngle);
        }

        if (Input.GetMouseButtonUp(0))
        {
            UnTakeObject(out takenObject);
        }
    }

    private void UnTakeObject(out RotatableObject takenObject)
    {
        takenObject = null;
    }

    private bool TryTakeObject(out RotatableObject takenObject)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.TryGetComponent<RotatableModel>(out var wheel))
        {
            takenObject = wheel.HeadGameObject;
            return true;
        }
        UnTakeObject(out takenObject);
        return false;
    }

    /// <summary>
    /// Plug for mouse wheel Rotating
    /// </summary>
    /// <returns></returns>
    private float CheckRotationDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            return -180*Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            return 180 * Time.deltaTime;

        return 0;
    }
}
