using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public static JsonData jsonData;
    public static List<List<float>> listData;
    public static string path = "/DataSets/pos.json";

    public static List<List<float>> ReadJson()
    {
        PosArr dataArray = JsonMapper.ToObject<PosArr>(File.ReadAllText(Application.streamingAssetsPath + path));
        listData = dataArray.arr;
        Debug.Log("Json load success! " + listData.Count + " rows have been read!");
        return listData;
    }
}

public class PosArr
{
    public List<List<float>> arr { get; set; }
}
