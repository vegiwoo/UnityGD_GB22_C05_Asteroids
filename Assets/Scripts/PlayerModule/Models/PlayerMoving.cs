using System;
using Asteroids.Infrastructure.Interfaces;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    internal class PlayerMoving : IMoving
    {
        #region Propetries 
        public float MaxSpeed { get; }
        public float CurrentSpeed { get; }
        public int RotationAngle { get; }
        #endregion
        
        public event Action<(float x, float y, float z, float speed)> ChangedDirection;
        public event Action<(int side, int angle)> ChangedRotation;

        public PlayerMoving(float maxSpeed, int rotationAngle)
        {
            MaxSpeed =  CurrentSpeed = maxSpeed;
            RotationAngle = rotationAngle;
        }

        public void Move(float x, float y)
        {
            if (x != 0f || y != 0f)
            {
                ChangedDirection?.Invoke((x, 0 ,y, CurrentSpeed));
            }
            else
            {
                ChangedDirection?.Invoke((0, 0 ,0, 0));
            }
        }

        public void Rotate(int rotationSide)
        { 
            ChangedRotation?.Invoke((rotationSide != 0f ? rotationSide : 0, rotationSide != 0f ? RotationAngle : 0));

        }
    }
}