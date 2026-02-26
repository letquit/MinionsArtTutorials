using System;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderPosition : MonoBehaviour
{
    public float radius = 1f;
    
    // Use this for initialization
    private void Start()
    {
        
    }
    
    // Update is called once per frame
    private void Update()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }
}
