using System;
using TinyBoat;
using UnityEngine;

public class DockSystem : MonoBehaviour
{
    public static event Action OnDockEnter;
    
    public GameObject player;
    public Transform playerSpawnPoint;
    public Transform boat;

    public bool canExit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            canExit = true;
            boat = other.transform;
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
        if (Input.GetKeyDown(KeyCode.E) && canExit)
        {
            OnDockEnter?.Invoke();
            player.transform.position = playerSpawnPoint.position;
            player.SetActive(true);
           player.transform.position = playerSpawnPoint.position;
            GameManager.Instance.SwitchToPlayer();
        }
    }
}
