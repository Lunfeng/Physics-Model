using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder : MonoBehaviour
{
    Mesh mesh = new Mesh();
    Vector3[] vertices = { };
    int[] triangles = { };
    List<int> tang;

    public void CalculateMesh(List<Vector3> vertices) 
    {
        int totalRows = vertices.Count / 30;
        int rows;
        int vols;
        for(rows = 0; rows < totalRows - 1; rows++)
        {
            for(vols = 0; vols < 30; vols++)
            {
                int[] temp =
                {
                    (rows * 30 + vols), ((rows + 1) * 30 + (vols + 1) % 30), ((rows + 1) * 30 + vols),
                    (rows * 30 + vols), (rows * 30 + ((vols + 1) % 30)), ((rows + 1) * 30 + (vols + 1) % 30)
                };
                tang.AddRange(temp);
            }
        }
    }
}
