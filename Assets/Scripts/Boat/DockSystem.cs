using System;
using UnityEngine;

public class DockSystem : MonoBehaviour
{
    public static event Action OnDockEnter;
    public static event Action OnDockExit;
    public static event Action OnPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            OnDockEnter?.Invoke();
            Debug.LogError("Dock enter");
        }

        if (other.CompareTag("Player"))
        {
            OnPlayerEnter?.Invoke();
            Debug.LogError("isPlayer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            OnDockExit?.Invoke();
            Debug.LogError("Dock exit");
        }
    }
}
