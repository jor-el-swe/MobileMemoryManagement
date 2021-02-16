using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Start(){
        //optimization 1:
        Resources.UnloadUnusedAssets();
        
        //optimization 2:
        //Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    public void nextScene(){
        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        currentBuildIndex++;
        if (currentBuildIndex >= SceneManager.sceneCountInBuildSettings)
            currentBuildIndex = 0;
        
        //optimization 1:
        //Resources.UnloadUnusedAssets();
        
        //optimization 2:
        Resources.UnloadUnusedAssets();
        GC.Collect();
        
        SceneManager.LoadScene(currentBuildIndex);
    }
}
