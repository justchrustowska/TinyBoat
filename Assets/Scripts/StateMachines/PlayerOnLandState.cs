using TinyBoat;
using Unity.VisualScripting;
using UnityEngine;

    public class PlayerOnLandState: IPlayerState
    {
        private PlayerBoatTrigger boatTrigger;
        private PlayerStateMachine _stateMachine;
        private CharacterController _controller;
        private Transform _camera;
        private float _speed = 5f;
        private Transform _boat;
        private bool _canEnterBoat;

        public PlayerOnLandState(PlayerStateMachine stateMachine, CharacterController controller, Transform camera)
        {
            _stateMachine = stateMachine;
            _controller = controller;
            _camera = camera;
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
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 direction = _camera.forward * input.y + _camera.right * input.x;
            direction.y = 0;
            direction.Normalize();

            _controller.Move(direction * _speed * Time.deltaTime);
        }
    }
    
