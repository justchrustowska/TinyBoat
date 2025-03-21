using TinyBoat;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    public PlayerMovementSystem player;
    public MovementSystem boat;
    public Transform boatEntryPoint;
    public Transform playerSpawnPoint;

    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera boatCamera;

    private bool isOnBoat = false;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
        controls.Player.Interact.performed += _ => ToggleControl();
        /*controls.Player.Look.performed += ctx => player.Look(ctx.ReadValue<Vector2>());
        controls.Player.Look.canceled += ctx => player.Look(Vector2.zero);
        controls.Player.MouseRight.performed += _ => player.SetLooking(true);
        controls.Player.MouseRight.canceled += _ => player.SetLooking(false);*/
    }

    private void ToggleControl()
    {
        if (isOnBoat)
        {
            // Zejście z łodzi
            isOnBoat = false;
            player.transform.position = boatEntryPoint.position;
            //player.gameObject.SetActive(true);
            //boat.gameObject.SetActive(false);
            playerCamera.Priority = 10;
            boatCamera.Priority = 5;
        }
        else
        {
            // Wejście na łódź
            isOnBoat = true;
            boat.transform.position = player.transform.position;
            //player.gameObject.SetActive(false);
           // boat.gameObject.SetActive(true);
            playerCamera.Priority = 5;
            boatCamera.Priority = 10;
        }
    }

    /*private void Update()
    {
        if (isOnBoat)
        {
            boat.SetThrottle(controls.Player.Move.ReadValue<Vector2>().y);
            boat.SetTurn(controls.Player.Move.ReadValue<Vector2>().x);
        }
        else
        {
            player.Move(controls.Player.Move.ReadValue<Vector2>());
        }
    }*/
}