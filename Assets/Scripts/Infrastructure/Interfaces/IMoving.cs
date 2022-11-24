using System;
using UniRx;

// ReSharper disable once CheckNamespace
namespace Asteroids.Infrastructure.Interfaces
{
    internal interface IMoving
    {
        #region Properties
        float MaxSpeed { get; set; }
        float CurrentSpeed { get; set; }
        event Action<(float x, float y, float z, float speed)> ChangedDirection;
        #endregion

        #region Functionality
        public void Move(float x, float y);
        #endregion
    }
}