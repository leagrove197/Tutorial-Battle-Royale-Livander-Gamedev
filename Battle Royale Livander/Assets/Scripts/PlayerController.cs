using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;

    public CharacterController characterController;

    [Header("Rotation")]
    public float rotationSpeed;

    private Vector2 rotation;

    
    [Header("Animation")]
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        float moveAnim = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat("Movement", moveAnim, 0.1f, Time.deltaTime);
        
        Vector3 movement = new Vector3(moveX, -1, moveZ);

        movement = transform.TransformDirection(movement);

        if (moveX == 0 && moveZ == 0) movement = Vector3.zero;
        
        characterController.Move(movement * movementSpeed * Time.deltaTime);
    }

    void Rotation()
    {
        rotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        rotation.y += Input.GetAxis("Mouse Y") * rotationSpeed;

        rotation.y = Mathf.Clamp(rotation.y, -10, 10);
        
        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, 0);
    }
}
