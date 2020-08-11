using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentDetails : MonoBehaviour
{
    [SerializeField] TextData textData;
    [SerializeField] TextMeshProUGUI[] experimentTextObjects;
    [SerializeField] float typingSpeed = 0.02f;

    int counter = 0;
    Coroutine co;

    public int Counter
    {
        set
        {
            counter = value;
        }
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            typingSpeed = 0.005f;
        }
        else
        {
            typingSpeed = 0.02f;
        }
    }

    public void WriteData()
    {
        if(co!=null)
        {
            StopCoroutine(co);
        }
        counter++;
        foreach (TextMeshProUGUI textobjects in experimentTextObjects)
        {
            textobjects.gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
        switch (counter%4)
        {
            case 1:
                EnterData("MATERIALS", 0);
                break;
            case 2:
                EnterData("PROCEDURE", 1);
                break;
            case 3:
                EnterData("RESULT", 2);
                break;
            case 0:
                EnterData("CONCLUSION", 3);
                break;
        }
    }

    void EnterData(string headingName, int dataIndex)
    {
        experimentTextObjects[0].GetComponent<TextMeshProUGUI>().text = headingName;
        TextToSpeech.instance.StartSpeak(textData.Data[dataIndex]);
        co=StartCoroutine(TypeOutText(dataIndex));
    }

    IEnumerator TypeOutText(int dataIndex)
    {
        foreach (char letter in textData.Data[dataIndex])
        {
            experimentTextObjects[1].GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
