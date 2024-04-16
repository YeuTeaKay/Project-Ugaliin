
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.EventSystems;

public class Character3DController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private CinemachineVirtualCamera playerCam;
    public float gravityScale = 1f;
    private Rigidbody rb;
    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    private void Awake()
    {
        playerCam = GameObject.Find("CM VCam").GetComponent<CinemachineVirtualCamera>();
        playerCam.Follow = this.gameObject.transform;
        playerCam.LookAt = this.gameObject.transform;
        //playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Handle3DMovement();
        ApplyGravity();
        HandleAnimation();
    }

    // Handles the 3D movement
    private void Handle3DMovement()
    {
        // Get the player's movement input
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y).normalized * walkingSpeed;

        // Calculates the change in velocity by subtracting the current velocity (rb.velocity) from a target velocity (movement)
        Vector3 velocityChange = (movement - rb.velocity);
        
        // Clamp the velocity change to ensure the player doesn't exceed maximum speed
        velocityChange.x = Mathf.Clamp(velocityChange.x, -walkingSpeed, walkingSpeed);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -walkingSpeed, walkingSpeed);
        
        // Apply the velocity change
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    
    }

    // Handles the Gravity
    private void ApplyGravity()
    {
        // Apply custom gravity
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }

    private void HandleAnimation()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();

        // If there is no movement, stop the animation
        if (moveDirection.magnitude == 0)
        {
            playerAnimator.SetInteger("Anim", 0);
            return;
        }

        // Calculate the angle of movement relative to the forward direction of the player
        float angle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
        float angleRelativeToPlayer = Mathf.DeltaAngle(transform.eulerAngles.y, angle);

        // Moving forward
        if (angleRelativeToPlayer > -45f && angleRelativeToPlayer <= 45f)
        {
            playerAnimator.SetInteger("Anim", 3);
        }
        // Moving right
        else if (angleRelativeToPlayer > 45f && angleRelativeToPlayer <= 135f)
        {
            playerAnimator.SetInteger("Anim", -1);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        // Moving left
        else if (angleRelativeToPlayer > -135f && angleRelativeToPlayer <= -45f)
        {   
            playerAnimator.SetInteger("Anim", 1);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        // Moving backward
        else 
        {
            playerAnimator.SetInteger("Anim", 2);
        }
    }


}
