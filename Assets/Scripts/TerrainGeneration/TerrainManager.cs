using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : TerrainConfig
{
    public Terrain t;
    public Transform water;
    public PlayerManager player;
    [Header("Terrain Texture Settings")]
    public List<ProceduralUtils.LayerData> layers;

    [Header("Tree Generation Settings")]
    public bool generateTrees = true;

    public float treeScale;
    public List<ProceduralUtils.ThreeLayerData> treeLayers;

    [Header("Raft Generation Settings")]
    public bool generateRaftParts = true;

    public List<ProceduralUtils.RaftLayerData> raftLayers;
    private Vector2Int[] landmassCache;

    public static TerrainManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void UpdateTerrainData(float[,] data)
    {
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetHeights(0, 0, data);
        landmassCache = ProceduralUtils.GetLandmassPoints(data, (water.position.y - t.GetPosition().y) / t.terrainData.size.y);
        UpdateTerrainTexture(data);
        CreateTrees();
        PlaceRaftParts(10);
    }

    protected void UpdateTerrainTexture(float[,] data)
    {
        t.terrainData.alphamapResolution = size.x;
        t.terrainData.SetAlphamaps(0, 0, ProceduralUtils.GenerateTextureData(data, layers.ToArray()));
    }

    protected void CreateTrees()
    {
        if (generateTrees)
        {
            float[,] data = t.terrainData.GetHeights(0, 0, size.x, size.y);
            List<TreeInstance> trees = new List<TreeInstance>();

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    float heightValue = data[x, y];
                    for (int l = 0; l < treeLayers.Count; l++)
                    {
                        if (treeLayers[l].GiveThree(heightValue))
                        {
                            TreeInstance treeInstance = new TreeInstance();
                            treeInstance.prototypeIndex = treeLayers[l].index;
                            treeInstance.heightScale = treeScale;
                            treeInstance.widthScale = treeScale;
                            treeInstance.rotation = Random.Range(0, Mathf.PI * 2);
                            treeInstance.position = new Vector3((float)y / (float)size.y, 0, (float)x / (float)size.x);
                            trees.Add(treeInstance);
                        }
                    }
                }
            }

            t.terrainData.SetTreeInstances(trees.ToArray(), true);
            t.Flush();
        }
    }
    protected Vector3 Dostuff()
    {
        Vector2Int p = landmassCache[(int)Random.Range(0, landmassCache.Length)];
        float x = (float)p.x / size.x * t.terrainData.size.x;
        float z = (float)p.y / size.y * t.terrainData.size.z;
        Vector3 pw = new Vector3(z, 0, x);
        pw.y = t.SampleHeight(pw);
        return pw;
    }

    protected void PlaceRaftParts(int amount)
    {
        if (generateRaftParts)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject raft = Instantiate(raftLayers[0].raftPart.gameObject, Dostuff(), Quaternion.identity) as GameObject;
            }
        }
    }

    public void PlacePlayer()
    {

        Vector3 tmp = Dostuff();
        player.SetPosition(tmp);
    }
}
