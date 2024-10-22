using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 4f;

    private CharacterController controller;

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        moveDirection.y = -9.81f * Time.deltaTime;

        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
