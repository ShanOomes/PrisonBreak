using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapDisplay : TerrainConfig
{
    public Material mat = null;

    protected override void UpdateTerrainData(float[,] data)
    {
        if (mat != null)
        {
            mat.mainTexture = ProceduralUtils.GenerateTexture2D(data);
            mat.mainTexture.filterMode = FilterMode.Point;
            mat.mainTexture.wrapMode = TextureWrapMode.Clamp;
        }
    }
}
