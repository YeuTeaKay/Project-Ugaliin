using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cinemachine;

public class ThirdPersonMovement : NetworkBehaviour
{
    
    public CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float smoothVelocity;

    [SerializeField] private CinemachineVirtualCamera playerCamera;
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Check if this player is the local player
        if (isLocalPlayer)
        {
            // Assign the camera only for the local player
            playerCamera = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
            playerCamera.Follow = this.gameObject.transform;
            playerCamera.LookAt = this.gameObject.transform;
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
