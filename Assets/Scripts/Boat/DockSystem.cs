using System;
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
        if (canExit && Input.GetKeyDown(KeyCode.E))
        {
            OnDockEnter?.Invoke();
            player.SetActive(true);
            player.transform.position = playerSpawnPoint.position;
            GameManager.Instance.SwitchToPlayer();
            canExit = false;
        }
    }
}
