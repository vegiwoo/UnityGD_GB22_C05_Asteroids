using System;
using Cysharp.Threading.Tasks;
using EnemiesModule.Model;
using EnemiesModule.Presenter;
using EnemiesModule.View;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace EnemiesModule
{
    public class EnemiesManager : MonoBehaviour
    {
        private const float EnemyMaxHp = 79;
        
        [SerializeField] private AssetReferenceGameObject enemyPrefabReference;

        
        private readonly EnemyPresenter[] _enemies = new EnemyPresenter[10];

        private async void Start()
        {
            var enemyPrefab = await LoadGameObjectAsync(enemyPrefabReference);
            var enemyObject = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            var enemyView = enemyObject.AddComponent<EnemyView>();

            
            // var enemyLiving = new EnemyLiving(EnemyMaxHp);
            // var enemyPresenter = new EnemyPresenter(enemyView, enemyLiving);
            //
            // _enemies[0] = enemyPresenter;
        }

        
        
        
        
        
        private static async UniTask<GameObject> LoadGameObjectAsync(AssetReference reference)
        {
            var loadPrefabHandle = reference.LoadAssetAsync<GameObject>();
            await loadPrefabHandle.Task;

            if (loadPrefabHandle.Status != AsyncOperationStatus.Succeeded)
            {
                throw new Exception("Error loading asset from reference");
            }

            return loadPrefabHandle.Result;
        }
    }
}