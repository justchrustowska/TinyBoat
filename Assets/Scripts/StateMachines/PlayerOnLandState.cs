using TinyBoat;
using Unity.VisualScripting;
using UnityEngine;

    public class PlayerOnLandState: IPlayerState
    {
        private PlayerBoatTrigger boatTrigger;
        
        private PlayerStateMachine _stateMachine;
        
        private CharacterController _controller;
        
        private Transform _camera;
        private Transform _boat;
        private Transform _playerTransform;
        
        private float _speed = 10f;
        private float _rotationSpeed = 80f;

        public PlayerOnLandState(PlayerStateMachine stateMachine, CharacterController controller, Transform camera)
        {
            _stateMachine = stateMachine;
            _controller = controller;
            _camera = camera;
            _playerTransform = controller.transform;
        }
        
        public void Enter()
        {
            Debug.Log("Entered OnFoot State");
        }

        public void Exit()
        {
            Debug.Log("Exited OnFoot State");
            
        }

        public void Tick()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical"); 
            
            Vector3 move = _playerTransform.forward * vertical;
            _controller.Move(move * _speed * Time.deltaTime);
            
            if (horizontal != 0f)
            {
                _playerTransform.Rotate(Vector3.up * horizontal * _rotationSpeed * Time.deltaTime);
            }
        }
    }
    
