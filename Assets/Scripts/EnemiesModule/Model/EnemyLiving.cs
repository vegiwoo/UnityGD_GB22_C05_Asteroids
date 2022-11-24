using UniRx;

namespace EnemiesModule.Model
{
    public class EnemyLiving
    {
        public ReactiveProperty<float> CurrentHp { get; }
        public ReactiveProperty<bool> IsDead { get; }

        public EnemyLiving(float maxHp)
        {
            CurrentHp = new ReactiveProperty<float>(maxHp);
            IsDead = (ReactiveProperty<bool>)CurrentHp
                .Select(x => x <= 0)
                .ToReactiveProperty();
        }
    }
}
