﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMeshGridAreaHeightColorMap : MonoBehaviour
{
    Mesh mesh;
    Vector3[] Verticies;
    int[] Triangles;
    Vector2[] myUVs;

    public int xSize = 20;
    public int zSize = 20;

    public Renderer MapRenderer;
    public Color[] ColorMap;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateMesh();
        UpdateMesh();
        PaintMesh();
    }

    void CreateMesh()
    {
        //set size
        Verticies = new Vector3[(xSize + 1) * (zSize + 1)];

        //set uv coordinates
        myUVs = new Vector2[Verticies.Length];

        for (int count = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //fill in data
                float y = Mathf.PerlinNoise(x*.3f,z*.3f)*4; // noise scale factor
                Verticies[count] = new Vector3(x, y, z);
                count++;
            }
        }

        //uvs
        for (var i = 0; i < Verticies.Length; i++)
        {
            myUVs[i] = new Vector2(Verticies[i].x/xSize+.5f/xSize, Verticies[i].z/zSize+.5f/zSize);
        }

      
        //set dynamic size
        Triangles = new int[xSize * zSize * 6];
        int vertCount = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                Triangles[tris + 0] = vertCount + 0;
                Triangles[tris + 1] = vertCount + xSize + 1;
                Triangles[tris + 2] = vertCount + 1;
                Triangles[tris + 3] = vertCount + 1;
                Triangles[tris + 4] = vertCount + xSize + 1;
                Triangles[tris + 5] = vertCount + xSize + 2;

                vertCount++;
                tris += 6;
            }
            vertCount++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = Verticies;
        mesh.triangles = Triangles;
        mesh.uv = myUVs;
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
        mesh.RecalculateNormals();
    }

    void PaintMesh()
    {
        Texture2D texture = new Texture2D(xSize, zSize); //ammount in pixels
        texture.filterMode = FilterMode.Point;

         for (int y = 0; y < zSize; y++)
         {
            for (int x = 0; x < xSize; x++)
            {
                if (Verticies[x+y*(zSize+1)].y <= 1f) texture.SetPixel(x , y, ColorMap[0]);
                if (Verticies[x+y*(zSize+1)].y > 1f) texture.SetPixel(x , y, ColorMap[1]);
                if (Verticies[x+y*(zSize+1)].y > 2f) texture.SetPixel(x , y, ColorMap[2]);
                if (Verticies[x+y*(zSize+1)].y > 3f) texture.SetPixel(x , y, ColorMap[3]);
            }
        } 

        texture.Apply();
        MapRenderer.material.mainTexture = texture;
    }

    private void OnDrawGizmos()
    {
        if (Verticies == null) return;

        for (int i = 0; i < Verticies.Length; i++)
        {
            Gizmos.DrawSphere(Verticies[i], .1f);
        }
    }
}
