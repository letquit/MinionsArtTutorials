using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderInteractorHolder : MonoBehaviour
{
    private ShaderInteractorPosition[] interactors;
    private Vector4[] positions = new Vector4[100];
    private float[] radiuses = new float[100];
    private Vector4[] boxBounds = new Vector4[100];
    private Vector4[] rotations = new Vector4[100];
    private float[] textureIndex = new float[100];

    [Range(0, 1)]
    public float shapeCutoff;
    [Range(0, 1)]
    public float shapeSmoothness = 0.1f;
    
    // Start is called before the first frame update
    private void Start()
    {
        FindInteractors();
    }
    private void OnEnable()
    {
        FindInteractors();
    }


    private void FindInteractors()
    {
        interactors = FindObjectsByType<ShaderInteractorPosition>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    private void Update()
    {
        FindInteractors();
        for (int i = 0; i < interactors.Length; i++)
        {
            positions[i] = interactors[i].transform.position;
            radiuses[i] = interactors[i].radius;
            boxBounds[i] = interactors[i].transform.localScale;
            rotations[i] = interactors[i].transform.eulerAngles;
            textureIndex[i] = interactors[i].textureIndex;
        }
        Shader.SetGlobalVectorArray("_ShaderInteractorsPositions", positions);
        Shader.SetGlobalFloatArray("_ShaderInteractorsRadiuses", radiuses);
        Shader.SetGlobalFloatArray("_ShaderInteractorsIndices", textureIndex);
        Shader.SetGlobalVectorArray("_ShaderInteractorsBoxBounds", boxBounds);
        Shader.SetGlobalVectorArray("_ShaderInteractorRotation", rotations);
        Shader.SetGlobalFloat("_ShapeCutoff", shapeCutoff);
        Shader.SetGlobalFloat("_ShapeSmoothness", shapeSmoothness);

    }
}
