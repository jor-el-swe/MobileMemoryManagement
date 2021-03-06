using System;
using UnityEngine;

public class LoadResources : MonoBehaviour{
    private static int skyboxIndex = 0;
    private string loadPath = "skybox";
    private Skybox skybox;
    
    void Start(){
        skybox = Camera.main.GetComponent<Skybox>();
        
        //load the first skybox
        var material = Resources.Load<Material>(loadPath + "0");
        skybox.material = material;
    }
    
    
    public void LoadNextSkybox(){

        
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
      
        //load the next skybox material
        var material = Resources.Load<Material>(loadPath + skyboxIndex);
        skybox.material = material;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
