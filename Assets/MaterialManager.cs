using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;
using Random = UnityEngine.Random;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private List<AssetReference> materials;
    [SerializeField] private AssetReferenceGameObject cubeReference;
    [SerializeField] private AssetReference sceneReference;

    private GameObject _cube;
    private Renderer _cubeRenderer;

    private AsyncOperationHandle<SceneInstance> _loadSceneHandle;
    private AsyncOperationHandle<GameObject> _loadPrefabHandle;
    private  AsyncOperationHandle<Material> _loadMaterialHandle;
    
    private async void Awake()
    {
        // Синхронная загрузка ассетов
        // - может длиться долго
        // - для проектов которые сделали свои обертки для ассет-бандлов (обратная совместимость)
        // var loadPrefabHandleSync = cubeReference.LoadAssetAsync<GameObject>();
        // loadPrefabHandleSync.WaitForCompletion();
        
        
        // Загрузка GO
        _loadPrefabHandle = cubeReference.LoadAssetAsync<GameObject>();
        await _loadPrefabHandle.Task;
        
        if (_loadPrefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            _cube = _loadPrefabHandle.Result;
            Instantiate(_cube);
            _cubeRenderer = _cube.GetComponentInChildren<Renderer>();
        }

        // Загрузка сцены 
        //_loadSceneHandle = Addressables.LoadSceneAsync(sceneReference);

    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var index = Random.Range(0, materials.Count - 1);
        SetMaterialAsync(index).Forget();
    }

    private void OnDisable()
    {
        // Выгрузка ассетов
        Addressables.ReleaseInstance(_loadPrefabHandle);
        
        // Выгрузка сцены 
        // Addressables.UnloadSceneAsync(_loadSceneHandle);
    }
    

    // Вариант 1 - работа через корутину
    // - нежелательный способ, не выполнится если GO деактивируется до того как загрузится ресурс
    // private IEnumerator SetMaterialRoutine(int materialIndex)
    // {
    //     if (_loadMaterialHandle.IsValid())
    //     {
    //         // Очищает ресурсы
    //         Addressables.Release(_loadMaterialHandle);
    //     }
    //
    //     // Загрузка ресурса
    //     var materialReference = materials[materialIndex];
    //     _loadMaterialHandle = materialReference.LoadAssetAsync<Material>();
    //
    //     yield return _loadMaterialHandle;
    //
    //     // Проверка статуса AsyncOperationHandle<Material>
    //     if (_loadMaterialHandle.Status != AsyncOperationStatus.Succeeded) yield break;
    //     
    //     // Применение полученного результата
    //     _cubeRenderer.material = _loadMaterialHandle.Result;
    // }
    
    // Вариант 2 - асинхронная загрузка материалов
    // - предпочтительный способ, выполнится в любом случае
    private async UniTask SetMaterialAsync(int materialIndex)
    {
        if (_loadMaterialHandle.IsValid())
        {
            // Очищает ресурсы
            Addressables.Release(_loadMaterialHandle);
        }
        
        // Определение нужной ссылки
        var materialReference = materials[materialIndex];
        
        // Асинхронная загрузка
        _loadMaterialHandle = materialReference.LoadAssetAsync<Material>();
        
        // Ожидание операции загрузки
        await _loadMaterialHandle.Task;
        
        // Проверка статуса AsyncOperationHandle<Material>
        if (_loadMaterialHandle.Status != AsyncOperationStatus.Succeeded) return;
        
        _cubeRenderer.material = _loadMaterialHandle.Result;
    }
}