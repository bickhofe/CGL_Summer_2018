using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMeshGrid : MonoBehaviour
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

        //set size
        Triangles = new int[3];
        //Triangles = new int[6];

        // step 1 
        Triangles[0] = 0;
        Triangles[1] = xSize + 1;
        Triangles[2] = 1;
        //Triangles[3] = 1;
        //Triangles[4] = xSize + 1;
        //Triangles[5] = xSize + 2;
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
