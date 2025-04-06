using System;
using UnityEngine;

namespace TinyBoat
{
    public class SpawnPoint: MonoBehaviour
    {
        public string spawnID;

        private void Start()
        {
            if (SpawnManager.Instance != null)
            {
                SpawnManager.Instance.RegisterSpawn(spawnID, this);
            }
        }

        private void OnDestroy()
        {
            if (SpawnManager.Instance != null)
            {
                SpawnManager.Instance.UnregisterSpawn(spawnID);
            }
        }
    }
}