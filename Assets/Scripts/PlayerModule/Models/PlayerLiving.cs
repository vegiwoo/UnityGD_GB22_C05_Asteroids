using Asteroids.Infrastructure.Interfaces;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    public class PlayerLiving : ILiving
    {
        public float MaxHp { get; }
        public float CurrentHp { get; }

        public PlayerLiving(float maxHp)
        {
            MaxHp = CurrentHp = maxHp;
        }
    }
}