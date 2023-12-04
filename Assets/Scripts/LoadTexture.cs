using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadTexture : MonoBehaviour
{
    [SerializeField] AssetReferenceT<Sprite> sprite;
    [SerializeField] SpriteRenderer spriteRenderer;
  
    IEnumerator Start()
    {
        AsyncOperationHandle<Sprite> loadingOperation = Addressables.LoadAssetAsync<Sprite>(sprite);
        Debug.Log("Loading has started.");
        yield return loadingOperation;
        Debug.Log("Loading is finished.");
        spriteRenderer.sprite = loadingOperation.Result;
    }
}
