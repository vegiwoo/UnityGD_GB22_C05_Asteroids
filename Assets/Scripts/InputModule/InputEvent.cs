using Asteroids.Infrastructure;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.InputModule
{
    [CreateAssetMenu(fileName = "InputEvent", menuName = "Asteroids/Events/ InputEvent", order = 0)]
    internal class InputEvent : GameEvent<InputArgs> { }
}