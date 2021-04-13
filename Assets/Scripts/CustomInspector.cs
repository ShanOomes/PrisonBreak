using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IslandManager))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainManager manager = (TerrainManager)target;

        if(GUILayout.Button("Generate RaftParts"))
        {
            manager.PlaceRaftParts(100);
        }

        if (GUILayout.Button("Delete RaftParts"))
        {
            manager.clearRaftParts();
        }
    }
}
