using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : TerrainConfig
{
    public Terrain t;

    [Header("Terrain Texture Settings")]
    public List<ProceduralUtils.LayerData> layers;

    protected override void UpdateTerrainData(float[,] data)
    {
        //Terrain t = Terrain.activeTerrain;
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetHeights(0, 0, data);
        UpdateTerrainData(data);
    }

    protected void UpdateTerrainTexture(float[,] data)
    {
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetAlphamaps(0, 0, ProceduralUtils.GenerateTextureData(data, layers.ToArray()));
    }
}
