using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // following the player
    public float smoothSpeed = 3f;
    public float mouseSensitivity = 100f;
    float xRotate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogError("Camera follow target not found");
            return;
        }

        transform.LookAt(player);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -100f, 100f);
        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
    }
}
