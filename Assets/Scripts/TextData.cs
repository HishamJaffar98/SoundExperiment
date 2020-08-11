using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Data")]
public class TextData : ScriptableObject
{
    [SerializeField] string[] data;

    public string[] Data
    {
        get
        {
            return data;
        }
    }
}
