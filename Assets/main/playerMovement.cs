using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    private Vector2 moveInput;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private IInteractable interact;
    private bool holdRotate = false;
    bool canDash = true, isDashing = false;
    public float dashDuration, dashCooldown;
    private IInteractable interactable;

    private void Update()
    {
        if(rb!=null)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>(); // Each player has their own PlayerInput
    }

    // Called automatically when "Move" action is performed
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HoldRotate(InputAction.CallbackContext context)
    {
        holdRotate = context.performed; // True when held, false when released
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
            interact.Interact();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        float startTime = Time.time;
        Vector3 dashDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed;
            yield return null;
        }

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // Move and rotate the player based on input
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
}
