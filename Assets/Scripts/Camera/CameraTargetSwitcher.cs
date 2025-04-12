using System;
using TinyBoat;
using UnityEngine;
using Unity.Cinemachine;

public class CameraTargetSwitcher : MonoBehaviour
{
    public GameObject boatTarget;
    public GameObject playerTarget;
    public CinemachineVirtualCameraBase virtualCamera;

    private PlayerStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = FindObjectOfType<PlayerStateMachine>();

        boatTarget = GameObject.FindGameObjectWithTag("Boat");
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        _stateMachine.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        _stateMachine.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(IState newState)
    {
        if (newState is PlayerOnLandState)
        {
            SwitchToPlayerTarget();
        }
        else if (newState is PlayerBoatState)
        {
            SwitchToBoatTarget();
        }
    }
    
    private void SwitchToPlayerTarget()
    {
        virtualCamera.Follow = playerTarget.transform;
        virtualCamera.LookAt = playerTarget.transform;
    }
    
    private void SwitchToBoatTarget()
    {
        virtualCamera.Follow = boatTarget.transform;
        virtualCamera.LookAt = boatTarget.transform;
    }
    
}
