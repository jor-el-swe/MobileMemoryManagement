using System;
using UnityEngine;

public class LoadResources : MonoBehaviour{
    private static int skyboxIndex = 0;
    
    void Start()
    {
        //load the first skybox
        
    }
    
    
    public void LoadNextSkybox(){
        skyboxIndex++;
        if (skyboxIndex >= 6){
            skyboxIndex = 0;
        }
      
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
