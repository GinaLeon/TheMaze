using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 directions;
    public float gravityScale = 0.5f;
    public float moveSpeed = 20f;
    public float jumpForce = 10f;
    private bool isJumping;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {if (controller.isGrounded)
        {gravityScale = -0.1f;
            if (Input.GetButtonDown("Jump"))
            {gravityScale = jumpForce;
                isJumping = true;
            }
    }
        gravityScale += Physics.gravity.y * Time.deltaTime;
        controller.Move(new Vector3(0, gravityScale, 0) * Time.deltaTime);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 lookVector = transform.forward;
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 playerRotation = new Vector3(0f, mouseX, 0f) * moveSpeed;
        transform.Rotate(playerRotation);
    if (Input.GetKey(KeyCode.RightArrow)){directions.x = 1;}
        else if (Input.GetKey(KeyCode.LeftArrow)) {directions.x = -1;}
        else {directions.x = 0;}
    if (Input.GetKey(KeyCode.UpArrow)){directions.z = 1; }// Changed value to 1 to match the moveSpeed
        else if (Input.GetKey(KeyCode.DownArrow)){directions.z = -1; } // Changed value to -1 to match the moveSpeed
        else{directions.z = 0;}
        directions.y += gravityScale * Time.deltaTime;
    if (Input.GetKeyDown(KeyCode.Space))
        {Jump();}
         directions = (lookVector * verticalInput + transform.right * horizontalInput).normalized;
    }
private void FixedUpdate()
    {controller.Move(directions * moveSpeed * Time.deltaTime);}
private void Jump()
    {directions.y = jumpForce;}
}


