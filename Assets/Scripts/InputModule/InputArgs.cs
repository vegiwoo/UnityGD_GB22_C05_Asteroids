using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.InputModule
{
    public sealed class InputArgs : EventArgs
    {
        #region Variables and constants

        public Vector2 MovingDestination { get; }
        public int RotationSide { get; } // left -1, right 1

        #endregion

        #region Properties

        #endregion

        #region Constructors & destructor
        public InputArgs(Vector2 movingDestination, int rotationSide)
         {
             MovingDestination = movingDestination;
             RotationSide = rotationSide;
         }
        #endregion

        #region Functionality

        public override string ToString()
        {
            return $"Moving: x {MovingDestination.x}, y {MovingDestination.y}, rotation: {RotationSide}";
        }

        #endregion
    }
}