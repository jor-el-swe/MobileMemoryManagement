using System;
using UnityEngine;

public class SwitchAndDeleteSkybox : MonoBehaviour{
    public ScriptableMaterial [] ScriptableMaterials = new ScriptableMaterial[6];
    
    private Skybox skybox;
    private static int skyboxIndex = 0;


    private Material newMaterial;

    void Start()
    {
        skybox = GetComponent<Skybox>();
    }

    public void NextSkybox(){
        Destroy( skybox.material);
        skyboxIndex++;
        if ((skyboxIndex + 1) > ScriptableMaterials.Length){
            skyboxIndex = 0;
        }
        
        newMaterial =  Instantiate(ScriptableMaterials[skyboxIndex].material);
        skybox.material = newMaterial;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
