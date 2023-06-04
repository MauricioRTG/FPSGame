using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MouseLook : MonoBehaviour
{
    private GameObject player; // The player object the camera will follow
    private float minClamp = -45; // The minimum angle the camera can look down
    private float maxClamp = 45; // The maximum angle the camera can look up
    [HideInInspector]
    public Vector2 rotation; // The player's current rotation
    private Vector2 currentLookRot; // The camera's current rotation
    private Vector2 rotationVelocity = new Vector2(0, 0); // The speed at which the camera rotates
    public float lookSensitivity = 2; // How sensitive the camera is to mouse movement
    public float lookSmoothDamp = 0.1f; // How smooth the camera movement is

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Player input from the mouse 
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        // Limit how much the player can look up and down
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        //Rotate the character around based on the mouse x position.
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);
        //Smooth the current Y rotation for looking up and down.
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationVelocity.y, lookSmoothDamp);
        //Update the camera X rotation based on the values generated. 
        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);
    }

}
