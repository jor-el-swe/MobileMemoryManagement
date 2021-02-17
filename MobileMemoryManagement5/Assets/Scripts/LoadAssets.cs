using System;
using System.IO;
using UnityEngine;

public class LoadAssets : MonoBehaviour{
    private static int skyboxIndex = 0;
    private string skyboxName = "skybox";
    
    private Skybox skybox;
    private AssetBundle assetBundle;
//    private AssetBundle assetBundle1;
  //  private AssetBundle assetBundle2;
    //private AssetBundle assetBundle3;
    //private AssetBundle assetBundle4;
   // private AssetBundle assetBundle5;
    
    void Start(){
        skybox = Camera.main.GetComponent<Skybox>();
        
        assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"skybox0"));
        
        if (assetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        
        //load the first skybox
        var material = assetBundle.LoadAsset<Material>(skyboxName + "0");
        skybox.material = material;
    }
    
    public void LoadNextSkybox(){
        
        assetBundle.Unload(true);
        
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
      
        assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"skybox"+skyboxIndex));
        if (assetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        //load the next skybox material
        var material = assetBundle.LoadAsset<Material>(skyboxName + skyboxIndex);
        skybox.material = material;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
