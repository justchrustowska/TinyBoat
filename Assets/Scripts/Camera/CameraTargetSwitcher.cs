using System;
using TinyBoat;
using UnityEngine;
using Unity.Cinemachine;

public class CameraTargetSwitcher : MonoBehaviour
{
    public GameObject boatTarget;
    public GameObject playerTarget;
    public CinemachineVirtualCameraBase virtualCamera;

    private void Awake()
    {
        boatTarget = GameObject.FindGameObjectWithTag("Boat");
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToPlayerTarget();
        }

        if (GameManager.Instance.currentControlState == ControlState.ControllingBoat)
        {
            virtualCamera.Follow = boatTarget.transform;
            virtualCamera.LookAt = boatTarget.transform;
        }

        if (GameManager.Instance.currentControlState == ControlState.ControllingCharacter)
        {
            virtualCamera.Follow = playerTarget.transform;
            virtualCamera.LookAt = playerTarget.transform;
        }
    }

    /*void OnEnable()
    {
        DockSystem.OnDockEnter += SwitchToPlayerTarget;
        BoatBoarding.OnBoarding += SwitchToBoatTarget;
    }

    void OnDisable()
    {
        DockSystem.OnDockEnter -= SwitchToPlayerTarget;
        BoatBoarding.OnBoarding -= SwitchToBoatTarget;
    }*/

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
