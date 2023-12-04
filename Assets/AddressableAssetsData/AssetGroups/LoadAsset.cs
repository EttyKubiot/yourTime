using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAsset : MonoBehaviour
{
    
    [SerializeField] AssetReferenceT<GameObject> gameObject;
    [SerializeField] GameObject gameObjects;

    IEnumerator Start()
    {
        AsyncOperationHandle<GameObject> loadingOperation = Addressables.LoadAssetAsync<GameObject>(gameObject);
        Debug.Log("Loading has started.");
        yield return loadingOperation;
        Debug.Log("Loading is finished.");
        gameObjects = loadingOperation.Result;
        GameObject instantiateObject = Instantiate(gameObjects);
    }
}
