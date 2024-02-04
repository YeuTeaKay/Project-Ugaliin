using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThirdPersonMovement : NetworkBehaviour
{
    
    public CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float smoothVelocity;
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Check if this player is the local player
        if (isLocalPlayer)
        {
            // Assign the camera only for the local player
            AssignCamera();
        }
    }

    void AssignCamera()
    {
        // Here, you can assign the camera to the 'cam' variable
        // For example, assuming the camera is tagged as "MainCamera" in the scene
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (mainCamera != null)
        {
            cam = mainCamera.transform;
        }
        else
        {
            Debug.LogError("MainCamera not found. Make sure your camera is tagged as 'MainCamera'.");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
