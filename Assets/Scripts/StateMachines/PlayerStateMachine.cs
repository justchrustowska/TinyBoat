using System;
using System.Runtime.InteropServices.WindowsRuntime;
using TinyBoat;
using UnityEngine;

namespace TinyBoat
{
    public enum ControlState
    {
        ControllingBoat,
        ControllingCharacter,
        Menu,
        Inventory,
        Death
    }
    public class PlayerStateMachine : MonoBehaviour
    {
        public static GameManager Instance;
    }
}