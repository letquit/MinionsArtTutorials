using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderInteractorPosition : MonoBehaviour
{

    public float radius = 1f;

    [Range(0, 3)] public int textureIndex;
    
    // Update is called once per frame
    private void Update()
    {
        // remove if you want multiple interactors, only for example of single interactor
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }
}
