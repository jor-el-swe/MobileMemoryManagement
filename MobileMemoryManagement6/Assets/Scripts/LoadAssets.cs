using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAssets : MonoBehaviour{
    private static int skyboxIndex = 0;
    private string loadPath = "Assets/Materials/";
    private string assetName = "skybox";
    private string assetType = ".mat";
    private Skybox skybox;
    
    void Start(){
        skybox = Camera.main.GetComponent<Skybox>();
        
        Addressables.LoadAssetAsync<Material>(loadPath+assetName +"0" + assetType).Completed += OnLoadDone;
    }
    
    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<Material> obj)
    {
        //load the skybox material
        skybox.material = obj.Result;
    }

    public void LoadNextSkybox(){

        Addressables.Release(skybox.material);
        
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
        
        Addressables.LoadAssetAsync<Material>(loadPath+assetName + skyboxIndex + assetType).Completed += OnLoadDone;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        //Resources.UnloadUnusedAssets();
        //GC.Collect();
    }
}
