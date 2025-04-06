using TinyBoat;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ControlState currentControlState = ControlState.ControllingBoat;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SwitchToPlayer()
    {
        currentControlState = ControlState.ControllingCharacter;
    }

    public void SwitchToBoat()
    {
        currentControlState = ControlState.ControllingBoat;
    }

}