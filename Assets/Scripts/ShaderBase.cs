using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderBase : MonoBehaviour
{

    void Start()
    {
        //GameObject gameObject = new GameObject("Cube");
        gameObject.transform.position = Vector3.zero;

        //顶点数组
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
        //索引数组
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

          //不可跳跃设置索引值（否则会提示一些索引超出边界顶点   15直接20不可，要连续15-16）
          18,19,17,
          19,16,17,
        };

        //UV数组
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

        //重新计算网格的法线
        //在修改完顶点后，通常会更新法线来反映新的变化。法线是根据共享的顶点计算出来的。
        //导入到网格有时不共享所有的顶点。例如：一个顶点在一个纹理坐标的接缝处将会被分成两个顶点。
        //因此这个RecalculateNormals函数将会在纹理坐标接缝处创建一个不光滑的法线。
        //RecalculateNormals不会自动产生切线，因此bumpmap着色器在调用RecalculateNormals之后不会工作。然而你可以提取你自己的切线。
        mesh.RecalculateNormals();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        //Material/New Material 1
        //gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/New Material");
        //SendMessage("OnMeshCreated", SendMessageOptions.DontRequireReceiver);
    }

}