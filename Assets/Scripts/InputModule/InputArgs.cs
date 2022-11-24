using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.InputModule
{
    internal sealed class InputArgs : EventArgs
    {
        #region Variables and constants
        
        public Vector2 MovingDestination { get; }
        
        #endregion

        #region Properties

        #endregion

        #region Constructors & destructor
        public InputArgs(Vector2 movingDestination)
         {
             MovingDestination = movingDestination;
         }
        #endregion

        #region Functionality

        public override string ToString()
        {
            return $"Moving: x {MovingDestination.x}, y {MovingDestination.y}";
        }

        #endregion
    }
}