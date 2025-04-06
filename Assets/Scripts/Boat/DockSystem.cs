using System;
using TinyBoat;
using UnityEngine;

public class DockSystem : MonoBehaviour
{
    public static event Action OnDockEnter; // gracz wysiada z łodzi
    
    public GameObject player;
    public Transform playerSpawnPoint;

    public bool canExit = false;

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
        if (Input.GetKeyDown(KeyCode.E) && canExit)
        {
            OnDockEnter?.Invoke();
           player.transform.position = playerSpawnPoint.position;
            GameManager.Instance.SwitchToPlayer();
        }
    }
}
