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
        public Transform cameraRoot;

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
                Vector3 camForward = cameraRoot.forward;
                camForward.y = 0f; // nie interesuje nas góra/dół
                /*if (camForward != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(camForward);
                    cameraRoot.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
                }*/
                
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
                //Vector3 direction = (cameraRoot.forward * v + cameraRoot.right * h).normalized;
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



