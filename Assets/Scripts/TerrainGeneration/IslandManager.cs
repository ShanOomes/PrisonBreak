using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : TerrainManager
{
    [Header("Island Settings")]
    public float innerRadius;
    public float outerRadius;

    protected override void UpdateTerrainData(float[,] data)
    {
        data = ProceduralUtils.IslandFilter(data, innerRadius, outerRadius);
        base.UpdateTerrainData(data);
    }
}
