using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Transform cam;
    private float yVelocity; 
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // --- Déplacements ZQSD (AZERTY) ---
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += transform.forward;   // Avancer
        if (Input.GetKey(KeyCode.S)) move -= transform.forward;   // Reculer
        if (Input.GetKey(KeyCode.A)) move -= transform.right;     // Gauche
        if (Input.GetKey(KeyCode.D)) move += transform.right;     // Droite

        // --- Saut + Gravité ---
        if (controller.isGrounded)
        {
            yVelocity = -1f; // petite valeur négative pour bien coller au sol
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        Vector3 velocity = move.normalized * moveSpeed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);

        // --- Rotation souris ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
