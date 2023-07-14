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
    

    [SerializeField] Player player;
    [SerializeField] int playerStamina;
    [SerializeField] int staminaDecreaseAmount = 25;
    [SerializeField] int staminaIncreaseAmount = 25;
    [SerializeField] private bool isSprinting = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rigidBody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        speed = defaultSpeed;

        player = GetComponent<Player>();
        playerStamina = player.Stamina;
    }

    // Update is called once per frame
    void Update()
    {
        //Update player's stammina 
        playerStamina = player.Stamina;

        //Sprint
        Sprint();

        //Increase player stamina, only when is not sprinting
        if(!isSprinting)
        {
            player.IncreaseStamina(staminaIncreaseAmount);
        }
        

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

    private void Sprint()
    {
        //Shift key is held down, increase player speed only if the player's stamina is not 0
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            if (playerStamina > 0)
            {
                speed = defaultSpeed * accelerationFactor;
                player.DecreseStamina(staminaDecreaseAmount);
            }
            else
            {
                speed = defaultSpeed;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //Shift key is released return to default speed
        {
            isSprinting = false;
            speed = defaultSpeed;
        }
    }
}
