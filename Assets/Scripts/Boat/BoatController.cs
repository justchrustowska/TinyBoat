using System;
using UnityEngine;

namespace TinyBoat
{
    public class BoatController : MonoBehaviour
    {
        private Rigidbody _rb;
        private float _maxSpeed = 10f;
        
        public float speed;
        public float maxSpeed = 15f;
        public float currentVelocity;
        public float rotationSpeed = 50f;
        public GameObject playerOnBoard;
        
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            BoatBoarding.OnBoarding += ActivePlayerOnBoard;
            DockSystem.OnDockEnter += DeactivePlayerOnBoard;
        }

        private void OnDisable()
        {
            BoatBoarding.OnBoarding -= ActivePlayerOnBoard;
            DockSystem.OnDockEnter -= DeactivePlayerOnBoard;
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.currentControlState == ControlState.ControllingBoat)
            {

                if (Input.GetKey(KeyCode.W))
                    _rb.AddForce(transform.forward * speed);

                float rotationInput = Input.GetAxis("Horizontal");
                Vector3 rotation = Vector3.up * rotationInput * rotationSpeed * Time.fixedDeltaTime;
                _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotation));

                currentVelocity = _rb.velocity.magnitude;
                MaxSpeed();
            }
        }

        private void MaxSpeed()
        {
            if (currentVelocity > maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }
        }

        public void ActivePlayerOnBoard()
        {
            playerOnBoard.SetActive(true);
        }

        public void DeactivePlayerOnBoard()
        {
            playerOnBoard.SetActive(false);
        }
    }
}
