using EnemiesModule.Model;
using EnemiesModule.View;
using UniRx;

namespace EnemiesModule.Presenter
{
    public class EnemyPresenter
    {
        private readonly EnemyView _enemyView;
        private readonly EnemyLiving _enemyLiving;
        
        public EnemyPresenter(EnemyView enemyView, EnemyLiving enemyLiving)
        {
            _enemyView = enemyView;
            _enemyLiving = enemyLiving;
            
            //_enemyView.MyButton.OnClickAsObservable().Subscribe(_ => _enemyLiving.CurrentHp.Value -= 7);
            //_enemyView.MyToggle.OnValueChangedAsObservable().SubscribeToInteractable(_enemyView.MyButton);
            
            //_enemyLiving.CurrentHp.SubscribeToText(_enemyView.MyText);
            
            // _enemyLiving.IsDead
            //     .Where(isDead => isDead)
            //     .Subscribe(_ =>
            //     {
            //         _enemyView.MyToggle.interactable = _enemyView.MyButton.interactable = false;
            //     });
        }
    }
}