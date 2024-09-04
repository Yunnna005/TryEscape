using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xValue, zValue;
    float speed = 2.0f, rotationSpeed = 20.0f, mouseSensitivity = 3.0f;
    
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        xValue = Input.GetAxis("Horizontal");
        zValue = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
        
        Vector3 movement = transform.forward * zValue;
        movement += transform.right * xValue;
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 4.0f;
        }

        characterController.Move(movement * speed * Time.deltaTime);
    }


}
