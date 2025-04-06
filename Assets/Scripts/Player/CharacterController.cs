using System;
using TinyBoat;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour

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

    void Update()
    {
        if (GameManager.Instance.currentControlState == ControlState.ControllingCharacter)
        {
            /*Vector2 moveDir = _moveAction.ReadValue<Vector2>();
            Vector3 velocity = rb.velocity;
            velocity.x = moveDir.x * moveSpeed * Time.fixedDeltaTime;*/

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }
}



