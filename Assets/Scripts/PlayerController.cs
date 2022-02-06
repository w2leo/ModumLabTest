using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 movement
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, 0f, vertical);
        }
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
         transform.Translate(movement, transform);
    }

    private void RotatePlayer(float direction)
    {
        //transform.RotateAround(Vector3.up, direction * rotateSpeed);
        transform.Rotate(Vector3.up, direction * rotateSpeed);
    }


}
