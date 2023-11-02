using System;
using System.IO;
using UnityEngine;

public class DataSaves : MonoBehaviour
{
    [SerializeReference] private SomeObject _object;

    private string _path;
    private void Start()
    {
        _path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Test.json";
        LoadJson();
        SaveObject();
    }

    private void SaveObject()
    {
        var json = JsonUtility.ToJson(this);
        File.WriteAllText(_path, json);
        Debug.Log(_object);
    }

    private void LoadJson()
    {
        var json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, this);
        Debug.Log(_object);
    }
}
