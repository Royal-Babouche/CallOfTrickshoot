using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private Vector2 inputVector = Vector2.zero;
    [SerializeField] private float MoveSpeed = 3f;

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    private void Update()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
