using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for third-person movement of the character in the game.
/// Make sure that the object that will receive this script (the player) 
/// has the Player tag and the Character Controller component.
/// </summary>
public class TPS_Mini : MonoBehaviour
{
    [Tooltip("AudioSource for playing the running sound")]
    public AudioSource audioSource;
    [Tooltip("Clip that will play when the character is running")]
    public AudioClip runningClip;

    [Tooltip("Time delay between each footstep sound in seconds")]
    public float footstepDelay = 0.5f;

    [Tooltip("Speed at which the character moves. It is not affected by gravity or jumping.")]
    public float velocity = 5f;
    [Tooltip("This value is added to the speed value while the character is sprinting.")]
    public float sprintAdittion = 3.5f;
    [Tooltip("The higher the value, the higher the character will jump.")]
    public float jumpForce = 18f;
    [Tooltip("Stay in the air. The higher the value, the longer the character floats before falling.")]
    public float jumpTime = 0.85f;
    [Space]
    [Tooltip("Force that pulls the player down. Changing this value causes all movement, jumping and falling to be changed as well.")]
    public float gravity = 9.8f;

    float jumpElapsedTime = 0;

    // Player states
    bool isJumping = false;
    bool isSprinting = false;
    bool isCrouching = false;
    bool isRunning = false;
    bool isPlayingFootsteps = false;

    // Inputs
    float inputHorizontal;
    float inputVertical;
    bool inputJump;
    bool inputCrouch;
    bool inputSprint;

    Animator animator;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogWarning("Animator component is missing. Animations will not work.");
    }

    void Update()
    {
        // Input checkers
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        inputJump = Input.GetAxis("Jump") == 1f;
        inputSprint = Input.GetKey(KeyCode.LeftShift);
        inputCrouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.JoystickButton1);

        // Toggle crouch state
        if (inputCrouch)
            isCrouching = !isCrouching;

        // Handle animations
        if (cc.isGrounded && animator != null)
        {
            animator.SetBool("crouch", isCrouching);

            bool runningNow = inputHorizontal != 0 || inputVertical != 0;
            animator.SetBool("run", runningNow);

            isSprinting = runningNow && inputSprint;
            animator.SetBool("sprint", isSprinting);

            if (runningNow && !isPlayingFootsteps && cc.isGrounded)
            {
                isRunning = true;
                isPlayingFootsteps = true;
                StartCoroutine(PlayFootstepsWithDelay(velocity + (isSprinting ? sprintAdittion : 0)));
            }
            else if (!runningNow || !cc.isGrounded)
            {
                StopFootsteps();
            }
        }
        else if (!cc.isGrounded)
        {
            StopFootsteps();
        }

        if (animator != null)
            animator.SetBool("air", !cc.isGrounded);

        if (inputJump && cc.isGrounded)
        {
            isJumping = true;
        }

        HeadHittingDetect();
    }

    IEnumerator PlayFootstepsWithDelay(float currentSpeed)
    {
        while (isRunning)
        {
            if (!audioSource.isPlaying && runningClip != null)
            {
                audioSource.PlayOneShot(runningClip);
            }
            yield return new WaitForSeconds(footstepDelay / (currentSpeed / velocity));
        }
    }

    void StopFootsteps()
    {
        isRunning = false;
        isPlayingFootsteps = false;
        StopCoroutine(PlayFootstepsWithDelay(velocity));
    }

    private void FixedUpdate()
    {
        if (cc != null && gameObject.activeInHierarchy && cc.enabled)
        {
            float velocityAdittion = isSprinting ? sprintAdittion : 0;
            if (isCrouching)
                velocityAdittion = -(velocity * 0.50f);

            float directionX = inputHorizontal * (velocity + velocityAdittion) * Time.deltaTime;
            float directionZ = inputVertical * (velocity + velocityAdittion) * Time.deltaTime;
            float directionY = 0;

            if (isJumping)
            {
                directionY = Mathf.SmoothStep(jumpForce, jumpForce * 0.30f, jumpElapsedTime / jumpTime) * Time.deltaTime;
                jumpElapsedTime += Time.deltaTime;

                if (jumpElapsedTime >= jumpTime)
                {
                    isJumping = false;
                    jumpElapsedTime = 0;
                }
            }

            directionY -= gravity * Time.deltaTime;

            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            forward *= directionZ;
            right *= directionX;

            if (directionX != 0 || directionZ != 0)
            {
                float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }

            Vector3 verticalDirection = Vector3.up * directionY;
            Vector3 horizontalDirection = forward + right;

            Vector3 moviment = verticalDirection + horizontalDirection;

            if (float.IsNaN(moviment.x) || float.IsNaN(moviment.y) || float.IsNaN(moviment.z) ||
                float.IsInfinity(moviment.x) || float.IsInfinity(moviment.y) || float.IsInfinity(moviment.z))
            {
                Debug.LogError("Invalid movement vector detected! Skipping Move()");
                return;
            }

            cc.Move(moviment);
        }
        else
        {
            Debug.LogWarning("CharacterController is not active or enabled. Movement skipped.");
        }
    }

    void HeadHittingDetect()
    {
        float headHitDistance = 1.1f;
        Vector3 ccCenter = transform.TransformPoint(cc.center);
        float hitCalc = cc.height / 2f * headHitDistance;

        if (Physics.Raycast(ccCenter, Vector3.up, hitCalc))
        {
            jumpElapsedTime = 0;
            isJumping = false;
        }
    }
}
