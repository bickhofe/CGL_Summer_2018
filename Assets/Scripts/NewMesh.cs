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
            new Vector3(1, 0, 0)
            //,
            //new Vector3(1, 0, 1)
        };

        Triangles = new int[]
        {
            0,1,2
            //,
            //1,3,2
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = Verticies;
        mesh.triangles = Triangles;

        //mesh.RecalculateNormals();

    }
}
