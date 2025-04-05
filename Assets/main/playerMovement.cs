using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Vector2 moveInput;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Transform camTransform;
    private IInteractable interact;
    private bool holdRotate = false;
    private bool isDashing = false;
    private bool canDash = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        camTransform = Camera.main.transform;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HoldRotate(InputAction.CallbackContext context)
    {
        holdRotate = context.performed;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
            interact.Interact();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash && !isDashing)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(rb != null)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

        // Convert move input to camera-relative direction
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (right * moveInput.x + forward * moveInput.y).normalized;

        if (!holdRotate && moveDirection.sqrMagnitude > 0.01f)
        {
            rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }
        else if (holdRotate && moveDirection.sqrMagnitude > 0.01f)
        {
            rb.velocity = Vector3.zero;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;

        // Camera-relative dash direction
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 dashDirection = (right * moveInput.x + forward * moveInput.y).normalized;
        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward; // Default forward dash
        }

        rb.velocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
