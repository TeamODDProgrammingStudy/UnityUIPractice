using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConsoleDataPrinter : MonoBehaviour
{
    [SerializeField] private ScriptableTestData _scriptableTestData;

    private void Start()
    {
        PrintScriptable();
    }
    private void PrintScriptable()
    {
        Debug.Log( $"id : {_scriptableTestData.id}");
        foreach (var s in _scriptableTestData.Scripts)
        {
            Debug.Log(s);
        }

        foreach (var tc in _scriptableTestData.Data)
        {
            Debug.Log($"code : {tc.code}, {tc.x}/{tc.y}/{tc.z}");
        }
    }
}
