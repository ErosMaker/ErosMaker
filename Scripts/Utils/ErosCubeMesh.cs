using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErosCubeMesh : MonoBehaviour
{
    static public Vector3[] vertices = new Vector3[8];
    static public int[] triangles = new int[36];
    static public Vector3[] normals = new Vector3[8];
    static public Mesh mesh;
    public static Mesh PopulateMesh()
    {
        vertices[0] = new Vector3(-0.5f, -0.5f, -0.5f);
        vertices[1] = new Vector3(0.5f, -0.5f, -0.5f);
        vertices[2] = new Vector3(-0.5f, 0.5f, -0.5f);
        vertices[3] = new Vector3(0.5f, 0.5f, -0.5f);
        vertices[4] = new Vector3(-0.5f, -0.5f, 0.5f);
        vertices[5] = new Vector3(0.5f, -0.5f, 0.5f);
        vertices[6] = new Vector3(-0.5f, 0.5f, 0.5f);
        vertices[7] = new Vector3(0.5f, 0.5f, 0.5f);

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;
        triangles[6] = 1;
        triangles[7] = 3;
        triangles[8] = 5;
        triangles[9] = 5;
        triangles[10] = 3;
        triangles[11] = 7;
        triangles[12] = 5;
        triangles[13] = 7;
        triangles[14] = 4;
        triangles[15] = 4;
        triangles[16] = 7;
        triangles[17] = 6;
        triangles[18] = 4;
        triangles[19] = 6;
        triangles[20] = 0;
        triangles[21] = 0;
        triangles[22] = 6;
        triangles[23] = 2;
        triangles[24] = 2;
        triangles[25] = 6;
        triangles[26] = 3;
        triangles[27] = 3;
        triangles[28] = 6;
        triangles[29] = 7;
        triangles[30] = 4;
        triangles[31] = 0;
        triangles[32] = 1;
        triangles[33] = 4;
        triangles[34] = 1;
        triangles[35] = 5;

        normals[0] = Vector3.forward;
        normals[1] = Vector3.forward;
        normals[2] = Vector3.forward;
        normals[3] = Vector3.forward;
        normals[4] = Vector3.forward;
        normals[5] = Vector3.forward;
        normals[6] = Vector3.forward;
        normals[7] = Vector3.forward;

        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;

        return mesh;
    }

    public static Mesh GetMesh()
    {
        ErosCubeMesh.PopulateMesh();
        return mesh;
    }
}
