using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class UniqueID : MonoBehaviour
{
    [ReadOnly, Serialize] public string _id = Guid.NewGuid().ToString();

    [SerializeField]
    private static SerializableDictionary<string, GameObject> idDatabase =
        new SerializableDictionary<string, GameObject>();

    public string ID => _id;

    private void OnValidate()
    {
        if(idDatabase.ContainsKey(_id)) Generate();
        else idDatabase.Add(_id, this.gameObject);
    }

    private void Generate()
    {
        _id = Guid.NewGuid().ToString();
        idDatabase.Add(_id, this.gameObject);
    }

    private void OnDestroy() {
        if(idDatabase.ContainsKey(_id)) idDatabase.Remove(_id);
    }
}
