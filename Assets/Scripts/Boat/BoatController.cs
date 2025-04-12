using System;
using UnityEngine;

namespace TinyBoat
{
    public class BoatController : MonoBehaviour
    {
        private PlayerStateMachine _stateMachine;
        private Rigidbody _rb;
        private float _maxSpeed = 10f;
        
        public float speed;
        public float maxSpeed = 15f;
        public float currentVelocity;
        public float rotationSpeed = 50f;

        public bool canSwim;
        
        
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void OnEnable()
        {
            _stateMachine.OnStateChanged += HandleStateChanged;
        }

        private void OnDisable()
        {
            _stateMachine.OnStateChanged -= HandleStateChanged;
        }

        private void HandleStateChanged(IState newState)
        {
            if (newState is PlayerOnLandState)
            {
                canSwim = false;
            }
            else if (newState is PlayerBoatState)
            {
               canSwim = true;
               Debug.Log("Can swim");
            }
        }

        void FixedUpdate()
        {
           if (canSwim)
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
        
    }
}
