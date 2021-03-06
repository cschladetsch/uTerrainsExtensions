﻿using System;
using System.Collections.Generic;
using UltimateTerrains;
using UltimateTerrainsEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif


[PrettyTypeName("Bandwidth")]
[Serializable]
public class BandwidthFilterSerializable : FilterNodeSerializable
{
    public override string Title {
        get { return "Bandwidth"; }
    }

    [SerializeField] private Vector2 bandwidth = new Vector2(-1, 1);

    public override void OnEditorGUI(UltimateTerrain uTerrain, IReadOnlyFlowGraph graph)
    {
#if UNITY_EDITOR
        EditorGUIUtility.labelWidth = 60;
        EditorUtils.CenteredBoxedLabelField(string.Format("out=1 if in∈[{0},{1}]\nout=0 otherwise", bandwidth.x, bandwidth.y));
        bandwidth = EditorUtils.MinMaxField(bandwidth);
        base.OnEditorGUI(uTerrain, graph);
        EditorGUIUtility.labelWidth = 0;
#endif
    }

    public override IGeneratorNode CreateModule(UltimateTerrain uTerrain, List<CallableNode> inputs)
    {
        return new BandwidthFilter(inputs[0], inputs[1], Intensity, bandwidth.x, bandwidth.y);
    }
}