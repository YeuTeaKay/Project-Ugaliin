using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    
    public CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float smoothVelocity;

    [SerializeField] private Animator animator;

    [SerializeField] private CinemachineVirtualCamera playerCamera;
    
    private bool hasCollided = false;

    public void Start()
    {
        playerCamera = GameObject.Find("CM VCam").GetComponent<CinemachineVirtualCamera>();
        playerCamera.Follow = this.gameObject.transform;
        playerCamera.LookAt = this.gameObject.transform;

        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
            Move();
 
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (vertical > 0) // Moving forward
            {
                animator.SetInteger("Anim", 3);
            }
            else if (vertical < 0) // Moving backward
            {
                animator.SetInteger("Anim", 2);
            }
            else // No forward/backward movement
            {
                animator.SetInteger("Anim", 0);
            }

            if (horizontal > 0) //Moving to the right
            {
                animator.SetInteger("Anim", -1); // Set the right-facing animation state
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (horizontal < 0) // Moving to the left
            {
                animator.SetInteger("Anim", 1); // Set the left-facing animation state
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                
            }   
        }
        else
        {
            // Set parameters in the Animator for idle state
            animator.SetInteger("Anim", 0);

        }

    }


}
