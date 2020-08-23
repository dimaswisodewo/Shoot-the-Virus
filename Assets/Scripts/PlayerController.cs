using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;

    private float movementSpeed = 12f;
    private float jumpHeight = 3f;
    private float groundDistance = 0.4f;
    private float mouseSensitivity = 100f;
    private float xRotation = 0f;
    private float gravity = -19.81f;
    private bool isGrounded;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        CameraRotation();
        PlayerMovement();
    }
    
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void PlayerMovement()
    {
        // handle player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = playerBody.right * x + playerBody.forward * z;
        characterController.Move(move * movementSpeed * Time.deltaTime);

        // handle player falling physics
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        // handle jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Debug.Log("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
