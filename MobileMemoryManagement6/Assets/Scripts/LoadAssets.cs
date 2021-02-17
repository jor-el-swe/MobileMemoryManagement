using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssets : MonoBehaviour{
    private static int skyboxIndex = 0;
    private string loadPath = "Assets/Materials/";
    private string assetName = "skybox";
    private string assetType = ".mat";
    private Skybox skybox;
    private static bool firstLoad = true;

    void Start(){
        skybox = Camera.main.GetComponent<Skybox>();
        
        Addressables.LoadAssetAsync<Material>(loadPath+assetName +"0" + assetType).Completed += OnLoadDone;
        Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Cube.prefab").Completed += CubeLoaded;
    }

    private void CubeLoaded(AsyncOperationHandle<GameObject> obj){
        Debug.Log("loaded rotating cube");
        Instantiate(obj.Result);
    }

    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<Material> obj)
    {
        if(!firstLoad) 
            Addressables.Release(skybox.material);
        firstLoad = false;
        
        //load the skybox material
        skybox.material = obj.Result;
    }


    public void LoadNextSkybox(){
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
        
        Addressables.LoadAssetAsync<Material>(loadPath+assetName + skyboxIndex + assetType).Completed += OnLoadDone;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        //Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
