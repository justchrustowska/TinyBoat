using UnityEngine;

    public class BoatIslandTrigger : MonoBehaviour
    {
        public Transform islandSpawnPoint;
        public string spawnIdOnIsland;
        private bool _boatInPort;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Boat"))
            {
                _boatInPort = true;
                Debug.Log("Boat in port");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boat"))
            {
                _boatInPort = false;
            }
        }

        public bool CanExitBoat()
        {
            return _boatInPort;
        }
    }