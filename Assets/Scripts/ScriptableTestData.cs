using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableTestData", menuName = "ScriptableObject/ScriptableTestData")]
public class ScriptableTestData : ScriptableObject
{
    public int id;
    public float number;
    public Sprite Image;
    public String[] Scripts;
    public TestClass[] Data;
}
