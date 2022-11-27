using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Asteroids/Stats/PlayerStats", order = 0)]
    internal sealed class PlayerStats : ScriptableObject
    {
        [Header("Living")]
        [SerializeField] public float maxHp = 100f;
        
        [Header("Movement")]
        [SerializeField] public float maxSpeed = 10f;
        [SerializeField] public int rotationAngele = 5;
    }
}

