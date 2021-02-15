using UnityEngine;

public class SwitchAndDeleteSkybox : MonoBehaviour{
    public ScriptableMaterial [] ScriptableMaterials = new ScriptableMaterial[6];
    
    private Skybox skybox;
    private static int skyboxIndex = 0;


    //private Material newMaterial;

    void Start()
    {
        skybox = GetComponent<Skybox>();
        skybox.material = Instantiate(ScriptableMaterials[skyboxIndex].material);
    }

    public void NextSkybox(){
        Destroy( skybox.material);
        
        skyboxIndex++;
        if ((skyboxIndex + 1) > ScriptableMaterials.Length){
            skyboxIndex = 0;
        }
        
        skybox.material = Instantiate(ScriptableMaterials[skyboxIndex].material);


        //optimization 1:
        Resources.UnloadUnusedAssets();
        
        //optimization 2:
        //Resources.UnloadUnusedAssets();
        //GC.Collect();
    }
}
