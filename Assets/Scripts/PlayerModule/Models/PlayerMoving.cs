using System;
using System.Numerics;
using Asteroids.Infrastructure.Interfaces;
using UniRx;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    internal class PlayerMoving : IMoving
    {
        public float MaxSpeed { get; set; }
        public float CurrentSpeed { get; set; }

        public event Action<(float x, float y, float z, float speed)> ChangedDirection;

        public PlayerMoving(float maxSpeed)
        {
            MaxSpeed =  CurrentSpeed = maxSpeed;
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
    }
}