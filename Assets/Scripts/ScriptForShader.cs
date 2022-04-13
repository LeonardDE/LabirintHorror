using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForShader : MonoBehaviour
{
    [SerializeField] private Shader _shader;

    protected Material _mat;

    private void Awake()
    {
        _mat = new Material(_shader);
    }

    private void Update()
    {
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {

    }
    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, _mat);
    }
}
