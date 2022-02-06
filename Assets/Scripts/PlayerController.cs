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
            Vector3 deltaPosition = currentPosition - mousePosition;
            mousePosition = currentPosition;
            return deltaPosition;
        }
    }

    private void Start()
    {
        isRotating = false;
    }

    private void Update()
    {
        MovePlayer();

        if (!isRotating && Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            mousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
            RotatePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime, transform);
    }

    private void RotatePlayer()
    {
        //transform.RotateAround(Vector3.up, direction * rotateSpeed);
        //Debug.Log(rotation);
        var x = Quaternion.Euler(rotation).eulerAngles;
        Debug.Log($"x = {x}");
        //transform.Rotate(Quaternion.Euler(rotation), rotateSpeed * Time.deltaTime);
       // transform.Rotate(x);
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
