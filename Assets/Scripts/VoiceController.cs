using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    void Start()
    {
        Setup(LANG_CODE);
        CheckPermission();
    }
    
    void CheckPermission()
    {
#if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
    }
}
