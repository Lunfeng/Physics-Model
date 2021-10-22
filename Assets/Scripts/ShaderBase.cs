using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderBase : MonoBehaviour
{

    void Start()
    {
        //GameObject gameObject = new GameObject("Cube");
        gameObject.transform.position = Vector3.zero;

        //��������
        Vector3[] _vertices =
        {
            // front
            new Vector3(-5.0f, 10.0f, -5.0f),
            new Vector3(-5.0f, 0.0f, -5.0f),
            new Vector3(5.0f, 0.0f, -5.0f),
            new Vector3(5.0f, 10.0f, -5.0f),


            // left
            new Vector3(-5.0f, 10.0f, -5.0f),
            new Vector3(-5.0f, 0.0f, -5.0f),
            new Vector3(-5.0f, 0.0f, 5.0f),//
            new Vector3(-5.0f, 10.0f, 5.0f),

            // back
            new Vector3(-5.0f, 10.0f, 5.0f),
            new Vector3(-5.0f, 0.0f, 5.0f),
            new Vector3(5.0f, 0.0f, 5.0f),
            new Vector3(5.0f, 10.0f, 5.0f),


            // right
            new Vector3(5.0f, 10.0f, 5.0f),
            new Vector3(5.0f, 0.0f, 5.0f),
            new Vector3(5.0f, 0.0f, -5.0f),
            new Vector3(5.0f, 10.0f, -5.0f),


            // Top
            new Vector3(-5.0f, 10.0f, 5.0f),
            new Vector3(5.0f, 10.0f, 5.0f),
            new Vector3(5.0f, 10.0f, -5.0f),
            new Vector3(-5.0f, 10.0f, -5.0f),

           // Bottom
            new Vector3(-5.0f, 0.0f, 5.0f),
            new Vector3(5.0f, 0.0f, 5.0f),
            new Vector3(5.0f, 0.0f, -5.0f),
            new Vector3(-5.0f, 0.0f, -5.0f),

        };
        //��������
        int[] _triangles =
        {
          //front
          2,1,0,
          0,3,2,
          //left
          4,5,6,
          4,6,7,
          //back
          9,11,8,
          9,10,11,
          //right
          12,13,14,
          12,14,15,
          //up
          //16,17,18,
          //16,18,19,
          //buttom
          20,23,22,
          22,21,20,

          //������Ծ��������ֵ���������ʾһЩ���������߽綥��   15ֱ��20���ɣ�Ҫ����15-16��
          18,19,17,
          19,16,17,
        };

        //UV����
        Vector2[] uvs =
        {
            // Front
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),


            // Left
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),


            // Back
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),


            // Right
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),

            // Top
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 1.0f),


            // Bottom
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 1.0f),

        };

        Mesh mesh = new Mesh()
        {
            vertices = _vertices,
            uv = uvs,
            triangles = _triangles,
        };

        //���¼�������ķ���
        //���޸��궥���ͨ������·�������ӳ�µı仯�������Ǹ��ݹ���Ķ����������ġ�
        //���뵽������ʱ���������еĶ��㡣���磺һ��������һ����������Ľӷ촦���ᱻ�ֳ��������㡣
        //������RecalculateNormals������������������ӷ촦����һ�����⻬�ķ��ߡ�
        //RecalculateNormals�����Զ��������ߣ����bumpmap��ɫ���ڵ���RecalculateNormals֮�󲻻Ṥ����Ȼ���������ȡ���Լ������ߡ�
        mesh.RecalculateNormals();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        //Material/New Material 1
        //gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/New Material");
        //SendMessage("OnMeshCreated", SendMessageOptions.DontRequireReceiver);
    }

}