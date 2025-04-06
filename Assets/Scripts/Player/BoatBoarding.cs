using System;
using UnityEngine;

namespace TinyBoat
{
    public class BoatBoarding : MonoBehaviour
    {
        public static event Action OnBoarding;
        public bool canBoard = false;
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canBoard = true;
                Debug.Log(other.name);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canBoard = false;
            }
        }

        void Update()
        {
            
            if (canBoard && Input.GetKeyDown(KeyCode.F))
            {
                OnBoarding?.Invoke();
                GameManager.Instance.SwitchToBoat();
            }
        }
    }
}