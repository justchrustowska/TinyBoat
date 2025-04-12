using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

    public class PlayerBoatState : IPlayerState
    {
        private PlayerStateMachine _stateMachine;
        private Rigidbody _boatRB;
        private Transform _boatTransform;
        private float _speed = 10f;
        private float _rotationSpeed = 30f;
        private BoatIslandTrigger _triggeredPort;
        private CharacterController _playerController;

        public float maxSpeed = 15f;

        public PlayerBoatState(PlayerStateMachine stateMachine, Transform boat)
        {
            _stateMachine = stateMachine;
            _boatTransform = boat;
        }

        public void Enter()
        {
            _boatTransform = _stateMachine.boatTransform;
            
            if (_boatTransform == null)
            {
                Debug.LogError("Boat Transform is null! Cannot control boat.");
                return;
            }
            
            _boatRB = _boatTransform.GetComponent<Rigidbody>();
            
            if (_boatRB == null)
            {
                Debug.LogError("Boat Rigidbody not found!");
            }
            
            GameObject playerObj = GameObject.FindWithTag("Player");
            playerObj.GetComponentInChildren<Renderer>().enabled = false;
            
            Debug.Log("Entered Boat State");
        }

        public void Exit()
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            playerObj.GetComponentInChildren<Renderer>().enabled = true;
            Debug.Log("Exited Boat State");
        }
        
        public void Tick()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _boatRB.AddForce(_boatTransform.forward * _speed, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _boatRB.AddForce(-_boatTransform.forward * _speed, ForceMode.Force);
            }

            float rotation = Input.GetAxis("Horizontal");
            _boatRB.AddTorque(Vector3.up * rotation * _rotationSpeed);
            
            if (_boatRB.velocity.magnitude > maxSpeed)
            {
               _boatRB.velocity = _boatRB.velocity.normalized * maxSpeed;
            }
            
            var allPorts = GameObject.FindObjectsOfType<BoatIslandTrigger>();
            _triggeredPort = allPorts.FirstOrDefault(p => p.CanExitBoat());

            if (_triggeredPort != null && Input.GetKeyDown(KeyCode.E))
            {
                ExitToIsland(_triggeredPort);
            }
        }

        public void ExitToIsland (BoatIslandTrigger port)
        {
            
            GameObject playerObj = GameObject.FindWithTag("Player");
            
            playerObj.GetComponentInChildren<Renderer>().enabled = true;
            playerObj.transform.position = port.islandSpawnPoint.position;
           
            CharacterController controller = playerObj.GetComponent<CharacterController>();
            Transform cam = Camera.main.transform;
            _stateMachine.SwitchState(new PlayerOnLandState(_stateMachine, controller, cam));

            Debug.Log("Exited Boat State");
        }
    }