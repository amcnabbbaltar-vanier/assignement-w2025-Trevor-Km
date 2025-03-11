using UnityEngine;
using Cinemachine;
using System;

[RequireComponent(typeof(Rigidbody))] // Ensures that a Rigidbody component is attached to the GameObject
public class CharacterMovement : MonoBehaviour
{
    // ============================== Movement Settings ==============================
    [Header("Movement Settings")]
    [SerializeField] private float baseWalkSpeed = 5f;    // Base speed when walking
    [SerializeField] private float baseRunSpeed = 8f;     // Base speed when running
    [SerializeField] private float rotationSpeed = 10f;   // Speed at which the character rotates

    // ============================== Jump Settings =================================
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;        // Jump force applied to the character
    [SerializeField] private float groundCheckDistance = 1.1f; // Distance to check for ground contact (Raycast)

    // ============================== Modifiable from other scripts ==================
    public float speedMultiplier = 1.0f; // Additional multiplier for character speed ( WINK WINK )

    // ============================== Private Variables ==============================
    private Rigidbody rb; // Reference to the Rigidbody component
    private Transform cameraTransform; // Reference to the camera's transform

    private float doubleJumpForce; // Double Jump force while power-up is active

   [SerializeField] private float speedBoostMultiplier = 2f; // Speed boost force while power-up is active 

    // Input variables
    private float moveX; // Stores horizontal movement input (A/D or Left/Right Arrow)
    private float moveZ; // Stores vertical movement input (W/S or Up/Down Arrow)
    private bool jumpRequest; // Flag to check if the player requested a jump
    private Vector3 moveDirection; // Stores the calculated movement direction

    public bool canDoubleJump;

    public bool speedBoost; // Determines whether or not a speed boost is active

    public bool doubleJumpRequest; // Determines whether or not a jump boost is active
    public int jumpCount; // The number of jumps a player has performed consecutively
  
    private static CharacterMovement instance;

    public AudioSource jumpSound; // Sound effect when a player jumps
    PlayerAnimatorController pac;
    // ============================== Animation Variables ==============================
    [Header("Anim values")]
    public float groundSpeed; // Speed value used for animations

    // ============================== Character State Properties ==============================
    /// <summary>
    /// Checks if the character is currently grounded using a Raycast.
    /// If false, the character is in the air.
    /// </summary>
    public bool IsGrounded => 
        Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, groundCheckDistance);

    /// <summary>
    /// Checks if the player is currently holding the "Run" button.
    /// </summary>
    private bool IsRunning => Input.GetButton("Run");

    // ============================== Unity Built-in Methods ==============================

    /// <summary>
    /// Called when the script is first initialized.
    /// </summary>
    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        InitializeComponents();
         // Initialize Rigidbody and Camera reference
    }

    /// <summary>
    /// Called every frame, used to register player input.
    /// </summary>
    private void Update()
    {
        RegisterInput(); // Collect player input
        SetJumpCount();
    }

    /// <summary>
    /// Called every physics update (FixedUpdate ensures physics stability).
    /// </summary>
    private void FixedUpdate()
    {
        HandleMovement(); // Process movement and physics-based updates
        
    }

    // ============================== Initialization ==============================

    /// <summary>
    /// Initializes Rigidbody and camera reference.
    /// Also locks and hides the cursor for better control.
    /// </summary>
    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        rb.freezeRotation = true; // Prevent Rigidbody from rotating due to physics interactions
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Smooth physics interpolation
        pac = GetComponent<PlayerAnimatorController>();
        jumpSound = GetComponent<AudioSource>();
        // Assign the main camera if available
        if (Camera.main)
            cameraTransform = Camera.main.transform;

        // Lock and hide the cursor for better gameplay control
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // ============================== Input Handling ==============================

    /// <summary>
    /// Reads player input values and registers movement/jump requests.
    /// </summary>
    private void RegisterInput()
    {
        moveX = Input.GetAxis("Horizontal"); // Get horizontal movement input
        moveZ = Input.GetAxis("Vertical");   // Get vertical movement input
        // Register a jump request if the player presses the Jump button
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            jumpRequest = true;
            jumpCount = 1;
        }

        if (Input.GetButtonDown("Jump") && !IsGrounded && canDoubleJump && jumpCount < 3){
            doubleJumpRequest = true;
            jumpCount = 2;
        }
       
    }

    // ============================== Movement Handling ==============================

    /// <summary>
    /// Handles movement-related logic: calculating direction, jumping, rotating, and moving.
    /// </summary>
    private void HandleMovement()
    {
        CalculateMoveDirection(); // Compute the movement direction based on input
        HandleJump(); // Process jump input
        RotateCharacter(); // Rotate the character towards the movement direction
        MoveCharacter(); // Move the character using velocity-based movement
        HandleDoubleJump();
    }

    /// <summary>
    /// Calculates the movement direction based on player input and camera orientation.
    /// </summary>
    private void CalculateMoveDirection()
    {
        // If the camera is not assigned, move based on world space
        if (!cameraTransform)
        {
            moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        }
        else
        {
            // Get forward and right vectors from the camera perspective
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            // Ignore Y-axis movement to prevent unwanted tilting
            forward.y = 0f;
            right.y = 0f;

            // Normalize vectors to maintain consistent movement speed
            forward.Normalize();
            right.Normalize();

            // Calculate movement direction relative to the camera orientation
            moveDirection = (forward * moveZ + right * moveX).normalized;
        }
    }
    private void SetJumpCount(){
       if(IsGrounded){
        jumpCount = 0;
       }
    }
    /// <summary>
    /// Handles jumping by applying an impulse force if the character is grounded.
    /// </summary>
    private void HandleJump()
    {
        // Apply jump force only if jump was requested and the character is grounded
        if (jumpRequest && IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply force upwards
            jumpRequest = false; // Reset jump request after applying jump
        }

    }

    private void HandleDoubleJump(){
       if(doubleJumpRequest && jumpCount == 2 && canDoubleJump){
         doubleJumpForce = jumpForce*1.5f;
        rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse); 
            doubleJumpRequest = false;
            pac.animator.SetTrigger("doubleJump");
            jumpSound.Play();
            jumpCount++;
       }
    }

    /// <summary>
    /// Rotates the character towards the movement direction.
    /// </summary>
    private void RotateCharacter()
    {
        // Rotate only if the character is moving
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Moves the character using Rigidbody's velocity instead of MovePosition.
    /// This ensures smooth movement while avoiding physics conflicts.
    /// </summary>
    private void MoveCharacter()
    {
        // Determine movement speed (walking or running)
        float speed = IsRunning ? baseRunSpeed : baseWalkSpeed;
        // Used to set the new velocity of the character
        Vector3 newVelocity;

        // Set ground speed value for animation purposes
        groundSpeed = (moveDirection != Vector3.zero) ? speed : 0.0f;
       
        

        if(!speedBoost){
            // Preserve the current Y velocity to maintain gravity effects
            newVelocity = new Vector3(
            moveDirection.x * speed * speedMultiplier, 
            rb.velocity.y, // Keep the existing Y velocity for jumping & gravity
            moveDirection.z * speed * speedMultiplier
        );
        }else{
            // Preserve the current Y velocity to maintain gravity effects
            newVelocity = new Vector3(
            moveDirection.x * speed * speedBoostMultiplier, 
            rb.velocity.y, // Keep the existing Y velocity for jumping & gravity
            moveDirection.z * speed * speedBoostMultiplier
        );
        }
        

        // Apply the new velocity directly
        rb.velocity = newVelocity;
    }
}
