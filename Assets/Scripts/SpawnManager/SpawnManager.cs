using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance;
        
        private Dictionary<string, SpawnPoint> spawnPoints = new Dictionary<string, SpawnPoint>();

        private void Awake()
        {
            if(Instance == null) 
                Instance = this;
            else Destroy(gameObject);
        }

        public void RegisterSpawn(string id, SpawnPoint spawnPoint)
        {
            if (!spawnPoints.ContainsKey(id))
            {
                spawnPoints.Add(id, spawnPoint);
            }
        }

        /*public void UnregisterSpawn(string id)
        {
            if (spawnPoints.ContainsKey(id))
            {
                spawnPoints.Remove(id);
            }
        }*/
        public Transform GetSpawn(string id)
        {
            return spawnPoints.ContainsKey(id) ? spawnPoints[id].transform : null;
        }

        /*public void SpawnPlayerAt(string id, GameObject player)
        {
            if (spawnPoints.TryGetValue(id, out SpawnPoint spawnPoint))
            {
                player.transform.position = spawnPoint.transform.position;
                player.transform.rotation = spawnPoint.transform.rotation;
                player.SetActive(true);
                GameManager.Instance.SwitchToPlayer();
            }
            else
            {
                Debug.LogWarning($"SpawnPoint '{id}' not found!");
            }*/
            
        }
