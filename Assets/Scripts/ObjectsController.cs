using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private Valve valve;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && valve == null)
        {
            TryTakeObject(out valve);
        }

        if (Input.GetMouseButton(0) && valve != null)
        {
            valve.RotateValve(CheckRotationDirection());
        }

        if (Input.GetMouseButtonUp(0))
        {
            UnTakeObject(out valve);
        }
    }

    private void UnTakeObject(out Valve valve)
    {
        valve = null;
    }

    private bool TryTakeObject(out Valve valve)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.TryGetComponent<Wheel>(out var w))
        {
            valve = w.ParentValve;
            return true;
        }
        UnTakeObject(out valve);
        return false;
    }

    /// <summary>
    /// Plug for mouse wheel Rotating
    /// </summary>
    /// <returns></returns>
    private float CheckRotationDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            return -1;
        if (Input.GetKey(KeyCode.RightArrow))
            return 1;

        return 0;
    }
}
