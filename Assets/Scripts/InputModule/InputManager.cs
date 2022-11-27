using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

// ReSharper disable once CheckNamespace
namespace Asteroids.InputModule
{
    [RequireComponent(typeof(PlayerInput))]
    internal sealed class InputManager : MonoBehaviour
    {
        #region Links
        
        [SerializeField] private InputEvent inputEvent;
        
        #endregion

        #region Variables & constants
        
        private PlayerInput _playerInput;
        
        private InputAction _moveAction;
        private InputAction _rotateAction;

        private Vector2 _movingDestination = Vector2.zero;
        private float _rotationSide = 0.00f;
        
        #endregion

        #region Properties

        #endregion

        #region Monobehavior methods

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _moveAction = _playerInput.actions[InputKey.Move.ToString()];
            _moveAction.performed += OnMoveActionHandler;
            _moveAction.canceled += OnMoveActionHandler;
            
            _rotateAction = _playerInput.actions[InputKey.Rotate.ToString()];
            _rotateAction.performed += OnRotateActionHandler;
            _rotateAction.canceled += OnRotateActionHandler;
        }

        private void OnDisable()
        {
            _moveAction.performed -= OnMoveActionHandler;
            _moveAction.canceled -= OnMoveActionHandler;
            
            _rotateAction.performed -= OnRotateActionHandler;
            _rotateAction.canceled -= OnRotateActionHandler;
        }

        #endregion

        #region Functionality

        private void OnMoveActionHandler(InputAction.CallbackContext context)
        {
            if(context.phase is not (InputActionPhase.Performed or InputActionPhase.Canceled)) return;
            
            _movingDestination = context.performed ? context.ReadValue<Vector2>() : Vector2.zero;
            Notify();
        }

        private void OnRotateActionHandler(InputAction.CallbackContext context)
        {
            if(context.phase is not (InputActionPhase.Performed or InputActionPhase.Canceled)) return;
            _rotationSide =  context.performed ? context.ReadValue<float>() : 0;
            Notify();
        }
        
        private void Notify()
        {
            inputEvent.Notify(new InputArgs(_movingDestination, (int)_rotationSide));
        }
        
        #endregion
    }
}
