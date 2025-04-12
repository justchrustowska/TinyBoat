using UnityEngine;
    public class PlayerBoatTrigger : MonoBehaviour
    {
        private PlayerStateMachine _stateMachine;
        
        private bool _canEnterBoat;
        private bool _canExitBoat;
        private void Start()
        {
            _stateMachine = GetComponent<PlayerStateMachine>();
        }

        private void Update()
        {
            if (_canEnterBoat && Input.GetKeyDown(KeyCode.F))
            {
                var playerStateMachine = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
                
                if (playerStateMachine != null)
                {
                    playerStateMachine.SwitchState(new PlayerBoatState(playerStateMachine, _stateMachine.boatTransform));
                    Debug.Log("Player entered boat");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BoatEntry"))
            {
                _canEnterBoat = true;
                //_boat = other.transform.parent;
                Debug.Log("PlayerBoatTrigger");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("BoatEntry"))
            {
                _canEnterBoat = false;
            }
        }
    }