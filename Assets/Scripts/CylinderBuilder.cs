using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBuilder : MonoBehaviour
{
    public Vector3 center = Vector3.zero;
    public Vector3 direction = Vector3.right;
    public float radius = 1f;
    public int sides = 30;
    public float scale = 5f;
    public int posIndex = 0;
    public float maxGap = 0.2f;

    List<Vector3> cylinderVertices;
    List<List<float>> data;
    float lastPos = -1;
    

    private void Start()
    {
        cylinderVertices = new List<Vector3>();
        data = JsonReader.ReadJson();
        for(int i = 0; i < 50; i++)
        {
            CalculateVertics();
        }
        ShowPos(cylinderVertices);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Drawing...");
            if (posIndex < 500) ;
                //CalculateVertics();
            //DrawCircle();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //ShowPos(cylinderVertices);
        }
    }

    public void CalculateVertics()
    {
        List<Vector3> curCircle;
        if(posIndex > 0 && lastPos > 0)
        {
            float gap = data[posIndex][0] - lastPos;

            if(gap <= 0)
            {
                posIndex++;
                return;
            }

            if (gap > maxGap)
            {
                int addGaps = (gap % maxGap == 0) ? (int)(gap / maxGap - 1) : (int)(gap / maxGap) + 1;
                float gapLength = gap / addGaps;
                Debug.Log("oldA: " + data[posIndex - 1][0] + " oldB: " + data[posIndex - 1][1] + " oldPos: " + data[posIndex - 1][2]);
                for (int i = 1; i < addGaps; i++)
                {

                    //float pos = (data[posIndex][0] - data[posIndex - 1][0]) / (addGaps + 1) * i + data[posIndex - 1][0];
                    //float a = (data[posIndex][1] - data[posIndex - 1][1]) / (addGaps + 1) * i + data[posIndex - 1][1];
                    //float b = (data[posIndex][2] - data[posIndex - 1][2]) / (addGaps + 1) * i + data[posIndex - 1][2];
                    float pos = Mathf.Lerp(data[posIndex - 1][0], data[posIndex][0], (float)i / (float)addGaps);
                    float a = Mathf.Lerp(data[posIndex - 1][1], data[posIndex][1], (float)i / (float)addGaps);
                    float b = Mathf.Lerp(data[posIndex - 1][2], data[posIndex][2], (float)i / (float)addGaps);
                    Debug.Log("a: " + a + " b: " + b + " pos: " + pos);
                    List<Vector3> temp = CircleBuilder.GenerateCirtleVertices(new Vector3(pos, 0, 0), direction, radius, sides, scale, a, b);
                    ShowPos(temp);
                    cylinderVertices.AddRange(temp);
                }
                Debug.Log("A: " + data[posIndex][0] + " B: " + data[posIndex][1] + " Pos: " + data[posIndex][2]);
                Debug.Log("Gap: " + gap + " addGaps: " + addGaps + " gaplength: " + gapLength);
            }
        }

        curCircle = CircleBuilder.GenerateCirtleVertices(new Vector3(data[posIndex][0], 0, 0), direction, radius, sides, scale, data[posIndex][1], data[posIndex][2]);
        lastPos = data[posIndex][0];
        cylinderVertices.AddRange(curCircle);

        posIndex++;
    }

    public void DrawCircle()
    {
        List<Vector3> a = CircleBuilder.GenerateCirtleVertices(new Vector3(data[posIndex][0], 0, 0), direction, radius, sides, scale, JsonReader.listData[posIndex][1], JsonReader.listData[posIndex][2]);
        cylinderVertices.AddRange(a);
        ShowPos(a);
        posIndex++;
    }

    void ShowPos(List<Vector3> circleData)
    {
        for (int i = 0; i < circleData.Count; i++)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            temp.transform.position = circleData[i];
            temp.name = i.ToString();
            temp.transform.SetParent(transform);
            Debug.DrawRay(Vector3.zero, Vector3.forward);
        }
    }
}
