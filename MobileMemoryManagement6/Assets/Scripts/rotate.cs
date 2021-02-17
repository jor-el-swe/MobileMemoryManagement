using UnityEngine;

public class rotate : MonoBehaviour
{
    // Update is called once per frame
    void Update(){
        transform.Rotate(0.05f,-0.1f,0.1f);
    }
}
