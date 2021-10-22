using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    Mesh mesh;

    void Start()
    {
        //mesh = new Mesh();
        //List<Vector3> circleData = CircleData.GenerateCirtlePostion(Vector3.zero, Vector3.forward, 1f, 20, 0);
        //mesh.vertices = circleData.ToArray();
        //GetComponent<MeshFilter>().mesh = mesh;
        //List<Vector3> circleData = CircleData.GenerateCirtlePostion(Vector3.zero, Vector3.forward, 1f, 20, 0);
        //ShowPos(circleData);
        //List<Vector3> circleData1 = CircleData.GenerateCirtlePostion(Vector3.one * 2, Vector3.right, 2f, 30, 0);
        //ShowPos(circleData1);
        List<Vector3> circleData2 = CircleData.GenerateCirtlePostion(new Vector3(1.2f, 2.3f, 3.4f), new Vector3(1.2f, 2.3f, 3.4f).normalized, 0.9f, 20, 0, 1.2f, 0.7f);
        ShowPos(circleData2);
        //List<Vector3> circleData3 = CircleData.GenerateCirtlePostion(new Vector3(4.2f, 2.3f, 6.4f), new Vector3(5.2f, 3.3f, 1.4f).normalized, 3, 7, 60, 0);
        //ShowPos(circleData3);
        //List<Vector3> circleData3 = CircleData.GenerateCirtlePostion(Vector3.zero, Vector3.forward, 1f, 20, 0);
        //ShowPos(circleData3);
    }

    void ShowPos(List<Vector3> circleData)
    {
        for (int i = 0; i < circleData.Count; i++)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            temp.transform.position = circleData[i];
            temp.name = i.ToString();
            temp.transform.SetParent(transform);
            Debug.DrawRay(Vector3.zero, Vector3.forward);
        }
    }

}
