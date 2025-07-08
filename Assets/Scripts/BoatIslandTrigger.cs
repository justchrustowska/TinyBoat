using System;
using Unity.VisualScripting;
using UnityEngine;

public class BoatIslandTrigger : MonoBehaviour
{
    public Transform islandSpawnPoint;
    public string spawnIdOnIsland;
    private bool _boatInPort;
    public Transform boatTransform;
    private PlayerStateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = FindObjectOfType<PlayerStateMachine>();
        if (_stateMachine == null)
        {
            Debug.LogWarning("PlayerStateMachine not found!");
        }
    }

    private void FixedUpdate()
    {
        SnapBoatToPort();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            _boatInPort = true;
            boatTransform = other.transform;
           // Debug.Log("Boat in port");
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

    public void SnapBoatToPort()
    {
        if (boatTransform == null)
        {
            Debug.LogWarning("Boat is missing!");
            return;
        }

        if (_boatInPort && _stateMachine != null && _stateMachine.CurrentState is PlayerOnLandState)
        {
            Rigidbody rb = boatTransform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            boatTransform.position = transform.position;
            boatTransform.rotation = transform.rotation;

            //Debug.Log("Boat snapped to port.");
        }
        else
        {
            Rigidbody rb = boatTransform.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}