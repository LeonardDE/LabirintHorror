using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogShader : ScriptForShader
{
    [SerializeField] private Color _nearColor;
    [SerializeField] private Color _farColor;
    [SerializeField] private float _farDepth;

    protected override void OnUpdate()
    {
        _mat.SetColor("_NearColor", _nearColor);
        _mat.SetColor("_FarColor", _farColor);
        _mat.SetFloat("_DepthFar", _farDepth);
    }
}

