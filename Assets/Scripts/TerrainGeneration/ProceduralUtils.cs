using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralUtils
{
    public static Texture2D GenerateTexture2D(float[,] data)
    {
        int width = data.GetLength(0);
        int height = data.GetLength(1);

        Texture2D texture = new Texture2D(width, height);
        Color[] colors = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = x + width * y;
                float value = data[x, y];
                colors[i] = new Color(value, value, value);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }

    public static float[,] IslandFilter(float [,] data, float innerRadius, float outerRadius)
    {
        int width = data.GetLength(0);
        int height = data.GetLength(1);
        Vector2Int middlePoint = new Vector2Int(width / 2, height / 2);
        for (int y = 0; y < data.GetLength(1); y++)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                Vector2Int point = new Vector2Int(x, y);
                float distance = Vector2.Distance(middlePoint, point);
                float multiplier;
                if (distance < innerRadius)
                {
                    multiplier = 1;
                }
                else if (distance > outerRadius)
                {
                    multiplier = 0;
                }
                else
                {
                    multiplier = Utils.Map(distance, innerRadius, outerRadius, 1f, 0f);
                }
                data[x, y] *= multiplier;
            }
        }

        return data;
    }
    public static float[,] GenerateTerrainData(int width, int height, float scale, float baseAmplitude, int octaves, float lacunarity, float persistence, Vector3 offset)
    {
        float[,] result = new float[width, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[x, y] = 0f;
                float frequency = scale;
                float amplitude = baseAmplitude;
                for (int o = 0; o < octaves; o++)
                {
                    frequency *= lacunarity;
                    amplitude *= persistence;
                    result[x, y] += (GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude) + offset.z / 100.0f);
                    if (result[x, y] > maxValue)
                    {
                        maxValue = result[x, y];
                    }
                    if (result[x, y] < minValue)
                    {
                        minValue = result[x, y];
                    }
                }
            }
        }
        return result;
    }

    public struct LayerData
    {
        public string name;
        public float heightTrigger;
        public float fadeAmount;
        public LayerData(string name, float heightTrigger, float fadeAmount)
        {
            this.name = name;
            this.heightTrigger = heightTrigger;
            this.fadeAmount = fadeAmount;
        }
    }
    public static float [,,] GenerateTextureData(float[,] terrainData, LayerData[] layers)
    {
        int width = terrainData.GetLength(0);
        int height = terrainData.GetLength(1);
        float[,,] map = new float[width, height, layers.Length];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = terrainData[x, y];
                for (int i = 0; i < layers.Length; i++)
                {
                    float mapValue;
                    float d = value - layers[i].heightTrigger;
                    if (i == 0)
                    {
                        mapValue = Mathf.Clamp(Utils.Map(d, 0, -layers[i].fadeAmount, 1f, 0f), 0, 1);

                        mapValue = value < layers[i].heightTrigger ? 1.0f : 0.0f;
                    }
                    else
                    {
                        if (value < layers[i].heightTrigger - layers[i].fadeAmount)
                        {
                            mapValue = Mathf.Clamp(Utils.Map(d, 0, -layers[i].fadeAmount, 1f, 0f), 0, 1);
                        }
                        else
                        {

                        }
                        mapValue = value < layers[i].heightTrigger && value > layers[i-1].heightTrigger ? 1.0f : 0.0f;
                    }
                    map[x, y, i] = mapValue;
                }
            }
        }
        return map;
    } 
    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x * frequency, y * frequency) * 2f - 1) * amplitude;

        return result;
    }
}
