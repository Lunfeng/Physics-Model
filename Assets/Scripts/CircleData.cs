using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleData : MonoBehaviour
{
    //public float Radius;
    //public int Sides;
    //public float AngleOffset;

    //List<Vector3> circleList;

    public static int deltaAngle = 12;
    public static float scale = 20;

    public static List<Vector3> GenerateCirtlePostion(Vector3 center, Vector3 direction, float radius, int sides, float offset)
    {
        if(Vector3.Angle(direction, Vector3.up) < 180 && Vector3.Angle(direction, Vector3.up) > 0) //判断方向向量与上向量夹角在0到180之间
        {
            List<Vector3> circleList = new List<Vector3>();
            float deltaAngle = 360 / sides;     //平分每个三角的角度
            for (int i = 0; i < sides; i++)     //计算每个顶点的相对位置
            {
                float angle = 180 - i * deltaAngle;
                float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                Vector3 RelativeRight = Vector3.Cross(Vector3.up, direction.normalized);        //计算方向向量的相对右向量，相对x轴
                Vector3 RelativeUp = Vector3.Cross(direction.normalized, RelativeRight.normalized);     //计算方向向量的相对上向量，相对y轴
                circleList.Add(center + RelativeRight.normalized * x + RelativeUp.normalized * y);      //将计算到的坐标x和y加到中心点上

            }

            return circleList;
        }
        else
        {
            throw new Exception("Circle direction invalid!");
        }
    }

    public static List<Vector3> GenerateCirtlePostion(Vector3 center, Vector3 direction, float radius, int sides, float offset, float a, float b)
    {
        if (Vector3.Angle(direction, Vector3.up) < 180 && Vector3.Angle(direction, Vector3.up) > 0) //判断方向向量与上向量夹角在0到180之间
        {
            List<Vector3> circleList = new List<Vector3>();
            //float deltaAngle = 360 / sides;     //平分每个三角的角度
            int deltaAngle = CircleData.deltaAngle;     //平分每个三角的角度
            sides = 360 / deltaAngle;
            for (int i = 0; i < sides; i++)     //计算每个顶点的相对位置
            {
                float angle = 180 - i * deltaAngle;
                float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad) * a * scale;
                float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad) * b * scale;
                Vector3 RelativeRight = Vector3.Cross(Vector3.up, direction.normalized);        //计算方向向量的相对右向量，相对x轴
                Vector3 RelativeUp = Vector3.Cross(direction.normalized, RelativeRight.normalized);     //计算方向向量的相对上向量，相对y轴
                circleList.Add(center + RelativeRight.normalized * x + RelativeUp.normalized * y);      //将计算到的坐标x和y加到中心点上

            }

            return circleList;
        }
        else
        {
            Debug.LogError("Invalid Angle!");
            throw new Exception("Circle direction invalid!");
        }
    }

    public static List<Vector3> GenerateCirtlePostion(Vector3 center, Vector3 direction, float a, float b, int sides, float offset)
    {
        if (Vector3.Angle(direction, Vector3.up) < 180 && Vector3.Angle(direction, Vector3.up) > 0) //判断方向向量与上向量夹角在0到180之间
        {
            List<Vector3> circleList = new List<Vector3>();
            float deltaAngle = 360 / sides;     //平分每个三角的角度
            //float length = 2 * Mathf.PI * b + 4 * (a - b);
            //Debug.Log(length);
            //sides = (int)(length / k);
            //Debug.Log(length / k);
            //float deltaAngle = 360 / sides;     //平分每个三角的角度
            //Debug.Log(deltaAngle);

            for (int i = 0; i < sides; i++)     //计算每个顶点的相对位置
            {
                float angle = 180 - i * deltaAngle;
                //float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                //float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                float x = a * Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = b * Mathf.Sin(angle * Mathf.Deg2Rad);
                Vector3 RelativeRight = Vector3.Cross(Vector3.up, direction.normalized);        //计算方向向量的相对右向量，相对x轴
                Vector3 RelativeUp = Vector3.Cross(direction.normalized, RelativeRight.normalized);     //计算方向向量的相对上向量，相对y轴
                circleList.Add(center + RelativeRight.normalized * x + RelativeUp.normalized * y);      //将计算到的坐标x和y加到中心点上

            }

            return circleList;
        }
        else
        {
            throw new Exception("Circle direction invalid!");
        }
    }
}
