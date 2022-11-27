using System;

// ReSharper disable once CheckNamespace
namespace Asteroids.Infrastructure.Interfaces
{
    internal interface IMoving
    {
        #region Properties
        float MaxSpeed { get; }
        float CurrentSpeed { get; }
        int RotationAngle { get; }
        event Action<(float x, float y, float z, float speed)> ChangedDirection;
        event Action<(int side, int angle)> ChangedRotation;
        #endregion

        #region Functionality
        public void Move(float x, float y);
        void Rotate(int rotationSide);

        #endregion
    }
}