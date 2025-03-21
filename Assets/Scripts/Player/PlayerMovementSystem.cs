using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSystem : MonoBehaviour

{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isLooking = false;

    private Transform cameraTransform;
    private float cameraRotationX = 0f;
    private PlayerControls _playerControls;
    private InputAction _moveAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Player.Move.Enable();
        _playerControls.Player.Look.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Move.Disable();
        _playerControls.Player.Look.Disable();
    }

    private void FixedUpdate()
    {
       Vector2 moveDir = _moveAction.ReadValue<Vector2>();
       Vector3 velocity = rb.velocity;
       velocity.x = moveDir.x * moveSpeed * Time.fixedDeltaTime;
       
    }


    /*public void Move(Vector2 input)
    {
        moveInput = input;
    }

    public void Look(Vector2 input)
    {
        lookInput = input;
    }

    public void SetLooking(bool looking)
    {
        isLooking = looking;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void Update()
    {
        HandleLook();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    private void HandleLook()
    {
        if (isLooking)
        {
            float mouseX = lookInput.x * rotationSpeed;
            float mouseY = lookInput.y * rotationSpeed;
            transform.Rotate(Vector3.up * mouseX);
        }
    }*/
}

