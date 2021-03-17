using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : TerrainManager
{
    [Header("Island Settings")]
    [Tooltip("Area of the center of the island that will remain untouched by the filter")]
    public float innerRadius;
    [Tooltip("Area at the edges of the island that will be completely flat.")]
    public float outerRadius;

    protected override void UpdateTerrainData(float[,] data)
    {
        data = ProceduralUtils.IslandFilter(data, innerRadius, outerRadius);
        base.UpdateTerrainData(data);
    }
}
