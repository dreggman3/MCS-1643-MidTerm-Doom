using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Settings
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    // Mouse Settings
    public float mouseSensitivity = 2f;
    public Transform cameraHolder;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }
    // Handles Movement of player character
    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // Camera horizontal rotation
        transform.Rotate(Vector3.up * mouseX);        
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
