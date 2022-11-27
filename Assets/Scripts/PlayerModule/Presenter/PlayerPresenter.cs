using System;
using Asteroids.Infrastructure.Interfaces;
using Asteroids.InputModule;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    internal sealed class PlayerPresenter : Infrastructure.IObserver<InputArgs>, IDisposable
    {
        #region Variables and constants

        private readonly PlayerView _playerView;
        private readonly ILiving _playerLiving;
        private readonly IMoving _playerMoving;

        #endregion

        #region Properties

        #endregion

        #region Constructors & destructor

        public PlayerPresenter(PlayerView playerView, ILiving playerLiving, IMoving playerMoving)
        {
            _playerView = playerView;
            _playerLiving = playerLiving;
            _playerMoving = playerMoving;
            
            Enable();
        }

        #endregion

        #region Functionality

        private void Enable()
        {
            _playerMoving.ChangedDirection += OnChangeDirection;
            _playerMoving.ChangedRotation += OnChangeRotation;
        }

        private void Disable()
        {
            _playerMoving.ChangedDirection -= OnChangeDirection;
        }

        public void OnEventRaised(Infrastructure.ISubject<InputArgs> subject, InputArgs args)
        {
            _playerMoving.Move(args.MovingDestination.normalized.x, args.MovingDestination.normalized.y);
            _playerMoving.Rotate(args.RotationSide);
        }
        
        private void OnChangeDirection((float x, float y, float z, float speed) obj)
        {
            var movement = GetMovement(_playerView.RigidBody, new Vector3(obj.x, obj.y, obj.z), obj.speed);
            _playerView.ChangeMovement(movement.horizontal, movement.vetrical);
        }
        
        private void OnChangeRotation((int side, int angle) obj)
        {
            var rotate = GetRotate(obj.side, obj.angle);
            _playerView.ChangeRotation(rotate);
        }

        #endregion

        private static (Vector3 horizontal, Vector3 vetrical) GetMovement(Component rb, Vector3 moveDirection, float moveSpeed)
        {
            var horizontal = Vector3.zero;
            var yertical = Vector3.zero;
        
            switch (moveDirection.x)
            {
                case > 0: 
                    horizontal = rb.transform.right * moveSpeed;
                    break;
                case < 0: 
                    horizontal = -rb.transform.right * moveSpeed;
                    break;
            }
            
            switch (moveDirection.z)
            {
                case > 0: 
                    yertical = rb.transform.forward * moveSpeed;
                    break;
                case < 0: 
                    yertical = -rb.transform.forward * moveSpeed;
                    break;
            }

            return (horizontal, yertical);
        }

        private static Vector3 GetRotate(float rotateSide, float step)
        {
            switch (rotateSide) 
            {
                case 1:
                    return new Vector3(0, step, 0);
                case -1:
                    return new Vector3(0, -step, 0);
                default:
                    return Vector3.zero;
            }
        }
 
        public void Dispose()
        {
            Disable();
        }
    }
}



// // ReSharper disable once CheckNamespace
// namespace Asteroids.PlayerModule
// {
//     public sealed class PlayerPresenter
//     {
//         
//         
//         // private readonly PlayerMovingView _playerMovingView;
//         // private readonly PlayerMovingModel _playerMovingModel;
//         //
//         // public PlayerMovingPresenter(PlayerMovingView playerMovingView, PlayerMovingModel playerMovingModel)
//         // {
//         //     _playerMovingView = playerMovingView;
//         //     _playerMovingModel = playerMovingModel;
//         //     Enable();
//         // }
//         //
//         // private void Enable()
//         // {
//         //     _playerMovingModel.Death += Death;
//         //     _playerMovingModel.ChangedHealth += ChangeHealth;
//         // }
//         //
//         // private void ChangeHealth(float  health){
//         //     _playerMovingView.ChangeHealth(health);
//         // }
//         //
//         // private void Death(){
//         //     _playerMovingView.Death();
//         //     Disable();
//         // }
//         //
//         // private void Disable()
//         // {
//         //     _playerMovingModel.Death -= Death;
//         //     _playerMovingModel.ChangedHealth -= ChangeHealth;
//         // }
//     }
// }