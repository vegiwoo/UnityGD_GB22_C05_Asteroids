using Asteroids.InputModule;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    internal sealed class PlayerManager : MonoBehaviour
    {
        #region Links

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private InputEvent inputEvent;

        #endregion

        #region Variables & constants
        
        private PlayerPresenter _playerPresenter;
        
        #endregion

        #region Properties
        

        #endregion

        #region Monobehavior methods
        
        private void OnEnable()
        {
            var playerGameObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            var playerView = playerGameObject.AddComponent<PlayerView>();
            var playerLiving = new PlayerLiving(playerStats.maxHp);
            var playerMoving = new PlayerMoving(playerStats.maxSpeed);
            
            _playerPresenter = new PlayerPresenter(playerView, playerLiving, playerMoving);
            
            inputEvent.Attach(_playerPresenter);
        }

        private void OnDisable()
        {
            inputEvent.Detach(_playerPresenter);
        }

        #endregion

        #region Functionality

        // private static async UniTask<GameObject> LoadGameObjectAsync(AssetReference reference)
        // {
        //     var loadPrefabHandle = reference.LoadAssetAsync<GameObject>();
        //     await loadPrefabHandle.Task;
        //
        //     if (loadPrefabHandle.Status != AsyncOperationStatus.Succeeded)
        //     {
        //         throw new Exception("Error when loading an asset asynchronously by reference.");
        //     }
        //
        //     return loadPrefabHandle.Result;
        // }
        
        #endregion
        
    }
}