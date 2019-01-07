using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMeshGridArea : MonoBehaviour
{
    Mesh mesh;
    Vector3[] Verticies;
    int[] Triangles;

    public int xSize = 20;
    public int zSize = 20;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateMesh();
        UpdateMesh();
    }


    void CreateMesh()
    {
        //set size
        Verticies = new Vector3[(xSize + 1) * (zSize + 1)];
        print(Verticies.Length);

        for (int count = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //fill in data
                //add noise float y = Mathf.PerlinNoise(x,z)*2f; // noise plus scale factor
                Verticies[count] = new Vector3(x, 0, z);
                count++;
            }
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

        mesh.RecalculateNormals();
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
