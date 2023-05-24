using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap, mesh }; //allows us to choose which map we want drawn so no code is overwritten
    public DrawMode drawMode;

    const int mapChunkSize = 241;
    [Range(0, 6)]
    public int levelOfDetail;
    public float noiseScale; //zooms in and out
    public bool autoUpdate; //updates value so you don't have to run code every time
    public int octaves; //numbers of layers on top of each other

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    [Range(0, 1)]
    public float persistence; //how clumped together everything is
    public float lacunarity; //how pixel-y it is

    public int seed; //different seeds have different maps
    public Vector2 offset;



    public TerrainType[] regions; //allows colors for different heights
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistence, lacunarity, offset);

        Color[] colourMap = new Color[mapChunkSize * mapChunkSize]; //loops through all values to assign colors
        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapChunkSize + x] = regions[i].colour;
                        break;
                    }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap) display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap)); //draws to output
        else if (drawMode == DrawMode.ColourMap) display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        else if (drawMode == DrawMode.mesh) display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
    }
    public void Start()
    {
        GenerateMap();
    }

    private void OnValidate() //regulates the variables to make sure inputs will work
    {
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }

    [System.Serializable]
    public struct TerrainType //each terrain has a name, height, color
    {
        public string name;
        public float height;
        public Color colour;
    }
}













