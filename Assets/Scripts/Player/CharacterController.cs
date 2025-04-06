using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyBoat
{


    public class CharacterController : MonoBehaviour

    {
        public float moveSpeed = 5f;
        public float rotationSpeed = 5f;

        private Rigidbody rb;

        [SerializeField] private Vector3 _startTransform;
        private PlayerControls _playerControls;
        private InputAction _moveAction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _playerControls = new PlayerControls();
            _startTransform = transform.position;
        }

        void Update()
        {
            if (GameManager.Instance.currentControlState == ControlState.ControllingCharacter)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
                transform.Translate(move);

                /*if (Input.GetMouseButton(1))
                {
                    float mouseX = Input.GetAxis("Mouse X");
                    transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
                }*/
            }

            if (GameManager.Instance.currentControlState == ControlState.ControllingBoat)
            {
                transform.position = _startTransform;
            }
        }
    }
}



