using UnityEngine;
using System;


namespace TinyBoat
{
    public class PortTrigger : MonoBehaviour
    {
        public static event Action OnDockEnter;
        
        public string spawnID;
        public GameObject player;

        private bool canExit = false;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            player.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Boat"))
            {
                canExit = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boat"))
            {
                canExit = false;
            }
        }

        void Update()
        {
            if (canExit && Input.GetKeyDown(KeyCode.E))
            {
                player.SetActive(true);
                SpawnManager.Instance.SpawnPlayerAt(spawnID, player);
                OnDockEnter?.Invoke();
                GameManager.Instance.SwitchToPlayer();
            }

            if (GameManager.Instance.currentControlState == ControlState.ControllingBoat)
            {
                player.SetActive(false);
            }
        }
    }
}