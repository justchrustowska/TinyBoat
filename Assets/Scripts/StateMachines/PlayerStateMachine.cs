using System;
using UnityEngine;

    public class PlayerStateMachine : MonoBehaviour
    {
        public IState CurrentState { get; private set; }
        public event Action<IState> OnStateChanged;
        public Transform boatTransform;
        

        void Start()
        {
            var controller = GetComponent<CharacterController>();
            var cam = Camera.main.transform;
            SwitchState(new PlayerOnLandState(this, controller, cam));

        }
        public void SwitchState(IPlayerState newState)
        {
            if (newState == null) return;
            if (newState == CurrentState) return;
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
            
            OnStateChanged?.Invoke(CurrentState);
        }

        private void Update()
        {
            if (CurrentState == null) return;

            CurrentState.Tick();
        }
        
    }