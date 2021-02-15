using System;
using UnityEngine;

public class SwitchSkybox : MonoBehaviour{
    public Material[] skyboxMaterials = new Material[6];
    private Skybox skybox;
    private static int skyboxIndex = 0;
    
    // Start is called before the first frame update
    void Start(){
        skybox = GetComponent<Skybox>();
    }
    
    public void NextSkybox(){
        skyboxIndex++;
        if ((skyboxIndex + 1) > skyboxMaterials.Length){
            skyboxIndex = 0;
        }
        skybox.material = skyboxMaterials[skyboxIndex];
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
