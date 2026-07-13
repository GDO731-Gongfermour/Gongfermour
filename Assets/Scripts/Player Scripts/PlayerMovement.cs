using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    Vector2 moveVector;
    Vector2 lookVector;

    Vector3 moveDirection;
    Rigidbody rb;

    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public float groundDrag;
    public Transform camTransform;

    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Move
        InputAction moveAction = InputSystem.actions.FindAction("Move");
        InputAction jumpAction = InputSystem.actions.FindAction("Jump");
        InputAction lookAction = InputSystem.actions.FindAction("Look");
        moveVector = moveAction.ReadValue<Vector2>();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        SpeedControl();

        //Jump
        if (jumpAction.triggered)
        {
            Jump();
        }

        //Camera movement
        lookVector = lookAction.ReadValue<Vector2>();
        transform.Rotate(Vector3.up * lookVector.x * 0.1f);
        camTransform.Rotate(Vector3.left * lookVector.y * 0.1f);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = this.gameObject.transform.forward * moveVector.y + this.gameObject.transform.right * moveVector.x;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        if (grounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.y);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}