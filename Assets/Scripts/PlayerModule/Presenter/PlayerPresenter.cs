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
        }

        private void Disable()
        {
            _playerMoving.ChangedDirection -= OnChangeDirection;
        }

        private void OnChangeDirection((float x, float y, float z, float speed) obj)
        {
            _playerView.ChangeDirection(new Vector3(obj.x, obj.y, obj.z), obj.speed);
        }

        #endregion

        public void OnEventRaised(Infrastructure.ISubject<InputArgs> subject, InputArgs args)
        {
            _playerMoving.Move(args.MovingDestination.normalized.x, args.MovingDestination.normalized.y);
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