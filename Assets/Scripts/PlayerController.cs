using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (verticalAxis != 0)
        {
            MovePlayer(verticalAxis * Time.deltaTime);

        }
        if (horizontalAxis != 0)
        {
            RotatePlayer(Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }

    private void MovePlayer(float direction)
    {
        Vector3 newPosition = transform.position + Vector3.forward * direction * moveSpeed;
        transform.Translate(newPosition);
    }

    private void RotatePlayer(float direction)
    {
        //transform.RotateAround(Vector3.up, direction * rotateSpeed);
        transform.Rotate(Vector3.up, direction * rotateSpeed);
    }


}
