using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBuilder : MonoBehaviour
{
    public static List<Vector3> GenerateCirtleVertices(Vector3 center, Vector3 direction, float radius, int sides, float a, float b)
    {
        if (Vector3.Angle(direction, Vector3.up) < 180 && Vector3.Angle(direction, Vector3.up) > 0) //�жϷ����������������н���0��180֮��
        {
            List<Vector3> circleList = new List<Vector3>();
            float deltaAngle = 360 / sides;     //ƽ��ÿ�����ǵĽǶ�
            //int deltaAngle = CircleBuilder.deltaAngle;     //ƽ��ÿ�����ǵĽǶ�
            //int sides;
            //sides = 360 / deltaAngle;
            for (int i = 0; i < sides; i++)     //����ÿ����������λ��
            {
                float angle = 180 - i * deltaAngle;
                float x = radius * Mathf.Cos(-angle * Mathf.Deg2Rad) * a;
                float y = radius * Mathf.Sin(-angle * Mathf.Deg2Rad) * b;
                Vector3 RelativeRight = Vector3.Cross(Vector3.up, direction.normalized);        //���㷽����������������������x��
                Vector3 RelativeUp = Vector3.Cross(direction.normalized, RelativeRight.normalized);     //���㷽����������������������y��
                circleList.Add(center + RelativeRight.normalized * x + RelativeUp.normalized * y);      //�����㵽������x��y�ӵ����ĵ���

            }

            return circleList;
        }
        else
        {
            Debug.LogError("Invalid Angle!");
            throw new Exception("Circle direction invalid!");
        }
    }
}
