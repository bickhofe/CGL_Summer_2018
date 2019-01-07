using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMesh : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] Verticies;
    public int[] Triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateMesh();
        UpdateMesh();
    }


    void CreateMesh()
    {
        Verticies = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),

            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1)
        };

        Triangles = new int[]
        {
            //bottom
            0,2,1,
            1,2,3,

            //top
            4,5,6,
            5,7,6
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = Verticies;
        mesh.triangles = Triangles;
        mesh.RecalculateNormals();
    }
}
