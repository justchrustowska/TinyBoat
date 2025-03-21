using UnityEngine;

namespace TinyBoat
{
    public class MovementSystem : MonoBehaviour
    {
        private Rigidbody _rb;
        private float _maxSpeed = 10f;
        
        public float speed;
        public float maxSpeed = 15f;
        public float currentVelocity;
        public float rotationSpeed = 50f;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
         _rb.AddForce(transform.forward * speed);
          
          float rotationInput = Input.GetAxis("Horizontal");
          Vector3 rotation = Vector3.up * rotationInput * rotationSpeed * Time.fixedDeltaTime;
          _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotation));
          
          currentVelocity = _rb.velocity.magnitude;
          MaxSpeed();
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
