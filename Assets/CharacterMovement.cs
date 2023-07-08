using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float defaultSpeed = 5;
    [SerializeField] float speed;
    [SerializeField] float accelerationFactor = 1.5f;
    [SerializeField] float jumpPower = 5;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] CapsuleCollider col;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rigidBody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();

        //Move
        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        //Jump
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            //Add upward force to the rigid body when we press jump.
            rigidBody.AddForce(Vector3.up * jumpPower , ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }

    //Shift key is held down, increase player speed
    //Shift key is released return to default speed
    private void Sprint()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = defaultSpeed * accelerationFactor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defaultSpeed;
        }
    }
}
