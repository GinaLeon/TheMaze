using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;
    float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
        xRotate-= mouseY;
        xRotate= Mathf.Clamp(xRotate,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
    }
}
