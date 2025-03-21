using System;
using UnityEngine;
using Unity.Cinemachine;

public class CameraTargetSwitcher : MonoBehaviour
{
    public GameObject boatTarget;
    public GameObject playerTarget;
    public CinemachineVirtualCameraBase virtualCamera;

    public bool isNearDock;
    public bool isPlayer;

    private void Awake()
    {
        boatTarget = GameObject.FindGameObjectWithTag("Boat");
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isNearDock && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToPlayerTarget();
        }

        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToBoatTarget();
        }
    }

    void OnEnable()
    {
        DockSystem.OnDockEnter += IsBoatNearDock;
        DockSystem.OnPlayerEnter += IsPlayerNearDock;
    }

    void OnDisable()
    {
        DockSystem.OnDockEnter -= IsBoatNearDock;
    }

    void IsBoatNearDock()
    {
        isNearDock = true;
    }

    void IsPlayerNearDock()
    {
        isPlayer = true;
    }

    void SwitchToPlayerTarget()
    {
        virtualCamera.Follow = playerTarget.transform;
        virtualCamera.LookAt = playerTarget.transform;
    }

    void SwitchToBoatTarget()
    {
        virtualCamera.Follow = boatTarget.transform;
        virtualCamera.LookAt = boatTarget.transform;
    }
}
