using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMeshProp : MonoBehaviour
{
    private Mesh mesh;
    private GameObject MeshProp;
    private GameObject Vertices;
    private GameObject Triangles;

    private void Start()
    {
        MeshProp = new GameObject("MeshProp-" + gameObject.name);
        if (GetComponent<MeshFilter>().mesh)
        {
            mesh = GetComponent<MeshFilter>().mesh;
            ShowVertices();
            ShowAllTriangle();
        }
    }

    public void OnMeshCreated()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        ShowVertices();
        ShowAllTriangle();
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireMesh(mesh);
        }
    }

    public void ShowVertices()
    {
        GameObject VtxObj;
        Vertices = new GameObject("Vertices-" + gameObject.name);
        Vertices.transform.SetParent(MeshProp.transform);
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            VtxObj = new GameObject(i.ToString());
            VtxObj.transform.position = mesh.vertices[i];
            VtxObj.transform.SetParent(Vertices.transform);
        }
    }

    public void ShowAllTriangle()
    {
        GameObject triangle;
        Mesh triangleMesh;
        Triangles = new GameObject("Triangles-" + gameObject.name);
        Triangles.transform.SetParent(MeshProp.transform);
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            triangle = new GameObject(mesh.triangles[i] + "-" + mesh.triangles[i + 1] + "-" + mesh.triangles[i + 2]);
            //triangle.transform.position = (mesh.vertices[mesh.triangles[i]] + mesh.vertices[mesh.triangles[i + 1]] + mesh.vertices[mesh.triangles[i + 2]]) / 3;
            triangle.transform.SetParent(Triangles.transform);
            triangleMesh = new Mesh();
            triangleMesh.vertices = new Vector3[3] { mesh.vertices[mesh.triangles[i]], mesh.vertices[mesh.triangles[i + 1]], mesh.vertices[mesh.triangles[i + 2]] };
            triangleMesh.triangles = new int[3] { 0, 1, 2 };
            triangleMesh.RecalculateNormals();
            triangle.AddComponent<MeshFilter>().mesh = triangleMesh;
            //Material/New Material 1
            triangle.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard")) { color = Color.blue };
        }

    }

}
