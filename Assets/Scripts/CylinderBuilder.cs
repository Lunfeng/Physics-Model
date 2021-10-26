using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBuilder : MonoBehaviour
{
    public Vector3 center = Vector3.zero;
    public Vector3 direction = Vector3.right;
    public float radius = 60f;
    public int sides = 40;
    public float maxGap = 0.012f;
    public float lengthScale = 1f;
    public int posIndex = 0;
    public int beginIndex = 0;
    public int endIndex = 7099;
    public int cutLength = 1000;
    public float rotateRadius = 5;

    List<Vector3> cylinderVertices;
    List<List<float>> data;
    //float lastPos = -1;
    int lastIndex;
    float lastPos;
    List<Vector3> lastVertices;
    GameObject ParticleStream;


    private void Start()
    {
        data = JsonReader.ReadJson();
        GenerateCylinder();

        //for (float i = 27.3f; i < 32f; i += 0.01f)
        //{
        //    GameObject a = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    a.name = i.ToString();
        //    a.transform.localScale = Vector3.one * 0.4f;
        //    a.transform.position = GenerateCenterPos(i, 1f);

        //}

        //while (posIndex < endIndex)
        //{
        //    int j = 0;
        //    List<Vector3> temp = new List<Vector3>();
        //    if (posIndex - 1 > 0)
        //    {
        //        temp.AddRange(lastVertices);
        //    }
        //    for (int i = posIndex; i < endIndex; i++)
        //    {
        //        CalculateVertics(temp);
        //        j++;
        //        if (j == cutLength)
        //            break;
        //    }
        //    MeshBuilder meshBuilder = new MeshBuilder();
        //    meshBuilder.CalculateMesh(temp, sides);
        //}
        //ShowPos(cylinderVertices);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Destroy(ParticleStream);
            GenerateCylinder();
        }
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    //ShowPos(cylinderVertices);
        //}
    }

    public void GenerateCylinder()
    {
        ParticleStream = new GameObject("ParticleStream");
        cylinderVertices = new List<Vector3>();
        lastVertices = new List<Vector3>();
        posIndex = beginIndex;
        lastIndex = -1;
        lastPos = -1;
        posIndex = Mathf.Clamp(posIndex, 0, data.Count);
        endIndex = Mathf.Clamp(endIndex, 0, data.Count);
        while (posIndex < endIndex)
        {
            int j = 0;
            List<Vector3> temp = new List<Vector3>();
            if (posIndex - 1 > 0)
            {
                temp.AddRange(lastVertices);
            }
            for (int i = posIndex; i < endIndex; i++)
            {
                CalculateVertics(temp);
                j++;
                if (j == cutLength)
                    break;
            }
            MeshBuilder meshbuilder = new MeshBuilder();
            meshbuilder.CalculateMesh(temp, sides, ParticleStream.transform);
        }
    }

    //public Vector3 GenerateCenterPos(int index, float scale)
    public Vector3 GenerateCenterPos(float pos, float scale)
    {
        //float pos = data[index][0];
        float angle1;
        float angle2;
        float z;
        float x;
        if (pos < 27.9)
        {
            z = pos;
            x = 0;
            //return new Vector3(0, 0, pos);
        }
        else if (pos < 28.5f)
        {
            angle1 = 270 + (pos - 27.9f) / (28.5f - 27.9f) * 45;
            z = 27.9f + rotateRadius * Mathf.Cos(angle1 * Mathf.Deg2Rad);
            x = rotateRadius + rotateRadius * Mathf.Sin(angle1 * Mathf.Deg2Rad);
            //return new Vector3(x, 0,  z);
        }
        else if (pos < 29.3f)
        {
            z = 27.9f + rotateRadius / Mathf.Sqrt(2f) + (pos - 28.5f) / Mathf.Sqrt(2f);
            x = rotateRadius - rotateRadius / Mathf.Sqrt(2f) + (pos - 28.5f) / Mathf.Sqrt(2f);
            //return new Vector3(x, 0, z);
        }
        else if (pos < 29.6f)
        {
            angle2 = 315 + (pos - 29.3f) / (29.6f - 29.3f) * 45;
            //z = (2 * (Mathf.Sqrt(2) * 27.9f + rotateRadius + 0.8f) - rotateRadius) / (2 * Mathf.Sqrt(2)) + rotateRadius / 2 * Mathf.Cos(angle2 * Mathf.Deg2Rad);
            z = 27.9f + (0.8f + rotateRadius / 2) / Mathf.Sqrt(2) + rotateRadius / 2 * Mathf.Cos(angle2 * Mathf.Deg2Rad);
            //z = 27.9f + (29.3f - 28.5f) / Mathf.Sqrt(2f) + rotateRadius * Mathf.Cos(angle2 * Mathf.Deg2Rad);
            //x = (2 * rotateRadius * (Mathf.Sqrt(2) - 1) + 1.6f + rotateRadius) / (2 * Mathf.Sqrt(2)) + rotateRadius / 2 * Mathf.Sin(angle2 * Mathf.Deg2Rad);
            x = rotateRadius + (0.8f - rotateRadius / 2) / Mathf.Sqrt(2) + rotateRadius / 2 * Mathf.Sin(angle2 * Mathf.Deg2Rad);
            //x = rotateRadius + (29.3f - 28.5f) / Mathf.Sqrt(2f) + rotateRadius * Mathf.Sin(angle2 * Mathf.Deg2Rad);
            //return new Vector3(x, 0, z);
        }
        else
        {
            z = 27.9f + (0.8f + rotateRadius / 2) / Mathf.Sqrt(2) + rotateRadius / 2;
            //z = 27.9f + (29.3f - 28.5f) / Mathf.Sqrt(2f) + rotateRadius;
            x = rotateRadius + (0.8f - rotateRadius / 2) / Mathf.Sqrt(2) + pos - 29.6f;
            //x = rotateRadius + (29.3f - 28.5f) / Mathf.Sqrt(2f) + pos - 29.6f;
            //return new Vector3(x, 0, z);
        }
        return new Vector3(-x, 0, z) * scale;
    }

    public Vector3 GetCenterDirection(float pos)
    {
        if (lastPos > 0)
        {
            Vector3 a = (GenerateCenterPos(pos, lengthScale) - GenerateCenterPos(lastPos, lengthScale)).normalized;
            return a;
        }
        else
        {
            return Vector3.forward;
        }
    }

    public void CalculateVertics(List<Vector3> tempList)
    {
        //List<Vector3> curCircle;
        if (posIndex > 0 && lastIndex >= 0)
        {
            //Debug.Log("Last Pos: " + lastIndex);
            float gap = data[posIndex][0] - data[lastIndex][0];
            //Debug.Log(data[posIndex][0] + " - " + data[lastIndex][0] + " = " + gap);
            //float gap = data[posIndex][0] - lastPos;

            if (gap <= 0)
            {
                posIndex++;
                return;
            }

            if (gap > maxGap)
            {
                int addGaps = (gap % maxGap == 0) ? (int)(gap / maxGap - 1) : (int)(gap / maxGap) + 1;
                float gapLength = gap / addGaps;
                //Debug.Log("oldA: " + data[lastIndex][1] + " oldB: " + data[lastIndex][2] + " oldPos: " + data[lastIndex][0]);
                for (int i = 1; i < addGaps; i++)
                {
                    float pos = Mathf.Lerp(data[lastIndex][0], data[posIndex][0], (float)i / (float)addGaps);
                    float a = Mathf.Lerp(data[lastIndex][1], data[posIndex][1], (float)i / (float)addGaps);
                    float b = Mathf.Lerp(data[lastIndex][2], data[posIndex][2], (float)i / (float)addGaps);
                    //Debug.Log("a: " + a + " b: " + b + " pos: " + pos);
                    //List<Vector3> temp = CircleBuilder.GenerateCirtleVertices(new Vector3(pos, 0, 0), direction, radius, sides, a, b);
                    List<Vector3> temp = CircleBuilder.GenerateCirtleVertices(GenerateCenterPos(pos, lengthScale), GetCenterDirection(pos), radius, sides, a, b);
                    //ShowPos(temp);
                    tempList.AddRange(temp);
                    lastPos = pos;
                }
                //Debug.Log("A: " + data[posIndex][1] + " B: " + data[posIndex][2] + " Pos: " + data[posIndex][0]);
                //Debug.Log("Gap: " + gap + " addGaps: " + addGaps + " gaplength: " + gapLength);
            }
        }

        lastVertices = CircleBuilder.GenerateCirtleVertices(GenerateCenterPos(data[posIndex][0], lengthScale), GetCenterDirection(data[posIndex][0]), radius, sides, data[posIndex][1], data[posIndex][2]);
        //lastVertices = CircleBuilder.GenerateCirtleVertices(new Vector3(data[posIndex][0], 0, 0), direction, radius, sides, data[posIndex][1], data[posIndex][2]);
        lastIndex = posIndex;
        tempList.AddRange(lastVertices);
        lastPos = data[posIndex][0];
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
