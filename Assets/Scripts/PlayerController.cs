using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 mousePosition;

    private bool isRotating;

    private Vector3 movement
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, 0f, vertical);
        }
    }
    private Vector3 rotation
    {
        get
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 deltaPosition = mousePosition - currentPosition;
            mousePosition = currentPosition;
            return new Vector3(deltaPosition.y, -deltaPosition.x, 0) * rotateSpeed;
        }
    }

    private void Start()
    {
        isRotating = false;
    }

    private void Update()
    {      
        MovePlayer();
        SetRotationStatus();
        RotatePlayer(isRotating);
    }

    private void SetRotationStatus()
    {
        if (!isRotating && Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            mousePosition = Input.mousePosition;
        }
        isRotating = Input.GetMouseButton(1);
    }

    private void MovePlayer()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer(bool isRotating)
    {
        if (!isRotating)
            return;
        transform.eulerAngles += Quaternion.Euler(rotation).eulerAngles;
    }
}
