using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 oldMousePosition;
    private bool isRotating;

    private Vector3 playerMovement
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, 0f, vertical);
        }
    }
    private Vector3 playerRotation
    {
        get
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 deltaPosition = currentMousePosition - oldMousePosition;
            oldMousePosition = currentMousePosition;
            return new Vector3(-deltaPosition.y, deltaPosition.x, 0);
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
        RotatePlayer();
    }

    private void SetRotationStatus()
    {
        if (!isRotating && Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            oldMousePosition = Input.mousePosition;
        }
        isRotating = Input.GetMouseButton(1);
    }

    private void MovePlayer()
    {
        transform.Translate(playerMovement * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        if (!isRotating)
            return;
        transform.eulerAngles += Quaternion.Euler(playerRotation * rotateSpeed).eulerAngles;
    }
}
