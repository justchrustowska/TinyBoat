using System;
using UnityEngine;

    public class SpawnPoint: MonoBehaviour
    {
        public string spawnID;

        private void Awake()
        {
            SpawnManager.Instance?.RegisterSpawn(spawnID, this);
        }
    }
