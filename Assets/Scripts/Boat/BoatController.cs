using System;
using UnityEngine;

namespace TinyBoat
{
    public class BoatController : MonoBehaviour
    {
        private PlayerStateMachine _stateMachine;
        private Rigidbody _rb;
        private float _enginePower = 1000f;
        private float _turnTorque = 500f;
        private float _dragInWater = 2f;
        private float _waterDrag = 0.5f;
        private float _angularWaterDrag = 1f;
        private float _angularDragInWater = 3f;
        private float _maxSpeed = 15f;
        private float _yaw = 0f;
        private float _pitch = 0f;
        
        public bool _canSwim;

        private void Awake()
        {
            _stateMachine = FindObjectOfType<PlayerStateMachine>();
        }
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.linearDamping = _dragInWater;
            _rb.angularDamping = _angularDragInWater;
            _rb.centerOfMass = Vector3.down * 0.5f; 
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
                _canSwim = false;
            }
            else if (newState is PlayerBoatState)
            {
               _canSwim = true;
               Debug.Log("Can swim");
            }
        }

        private void FixedUpdate()
        {
           if (_canSwim)
           {
               HandleMovement();
               ApplyWaterResistance();
           }
        }
        
        void HandleMovement()
        {
            float forwardInput = Input.GetAxis("Vertical");
            float turnInput = Input.GetAxis("Horizontal");
            
            Vector3 force = transform.forward * forwardInput * _enginePower * Time.fixedDeltaTime;
            
            if (_rb.linearVelocity.magnitude < _maxSpeed)
                _rb.AddForce(force);
            
            _rb.AddTorque(Vector3.up * turnInput * _turnTorque * Time.fixedDeltaTime);
        }
        
        void ApplyWaterResistance()
        {
            Vector3 velocity = _rb.linearVelocity;
            Vector3 resistance = -velocity.normalized * velocity.sqrMagnitude * _waterDrag * Time.fixedDeltaTime;

            _rb.AddForce(resistance, ForceMode.VelocityChange);
            
            Vector3 angularVelocity = _rb.angularVelocity;
            Vector3 angularResistance = -angularVelocity * _angularWaterDrag * Time.fixedDeltaTime;

            _rb.AddTorque(angularResistance, ForceMode.VelocityChange);
        }
    }
}
