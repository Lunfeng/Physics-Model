using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder : MonoBehaviour
{
    Mesh mesh;
    //Vector3[] vertice = { };
    //int[] triangles = { };
    List<int> tang;

    public void CalculateMesh(List<Vector3> vertices)
    {
        tang = new List<int>();
        int totalRows = vertices.Count / 30;
        int rows;
        int vols;
        for (rows = 0; rows < totalRows - 1; rows++)
        {
            for (vols = 0; vols < 30; vols++)
            {
                int[] temp =
                {
                    (rows * 30 + vols), ((rows + 1) * 30 + (vols + 1) % 30), ((rows + 1) * 30 + vols),
                    (rows * 30 + vols), (rows * 30 + ((vols + 1) % 30)), ((rows + 1) * 30 + (vols + 1) % 30)
                };
                tang.AddRange(temp);
            }
        }
        mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = tang.ToArray();
        mesh.RecalculateNormals();
        GameObject r = GameObject.Find("RenderObject");
        r.GetComponent<MeshFilter>().mesh = mesh;
        r.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));// { color = Color.blue };
        //ShowMesh(vertices, tang.ToArray());
    }

    public void ShowMesh(List<Vector3> vertices, int[] triangles)
    {
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;
        GameObject triangle;
        Mesh triangleMesh;
        GameObject Triangles = new GameObject("Mesh");
        //Triangles.transform.SetParent(MeshProp.transform);
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
