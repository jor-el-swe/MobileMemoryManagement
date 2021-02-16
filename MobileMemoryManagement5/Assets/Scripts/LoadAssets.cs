using System.IO;
using UnityEngine;

public class LoadAssets : MonoBehaviour{
    private static int skyboxIndex = 0;
    private string skyboxName = "skybox";
    
    private Skybox skybox;
    private AssetBundle myLoadedAssetBundle;
    
    void Start(){
        skybox = Camera.main.GetComponent<Skybox>();
        
        myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "materials"));
        
        if (myLoadedAssetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        
        //load the first skybox
        var material = myLoadedAssetBundle.LoadAsset<Material>(skyboxName + "0");
        skybox.material = material;
    }
    
    public void LoadNextSkybox(){
        
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
      
        if (myLoadedAssetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        //load the next skybox material
        var material = myLoadedAssetBundle.LoadAsset<Material>(skyboxName + skyboxIndex);
        skybox.material = material;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        //Resources.UnloadUnusedAssets();
        //GC.Collect();
    }
}
