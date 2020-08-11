using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TextSpeech;

public class ButtonController : MonoBehaviour
{
    [Header("Labels")]
    [SerializeField] TextMeshProUGUI[] labelArray;

    [Header("Display Objects")]
    [SerializeField] GameObject explanatationObjects;
    [SerializeField] GameObject infoPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLabels()
    {
        foreach(TextMeshProUGUI label in labelArray)
        {
            if(label.gameObject.activeSelf==true)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                label.gameObject.SetActive(true);
            }
        }
    }

    public void SwitchLevel()
    {
        TextToSpeech.instance.StopSpeak();
        StartCoroutine(SwitchLevelCoroutine());
    }

    IEnumerator SwitchLevelCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
    public void ToggleExplanation()
    {
        if (explanatationObjects.activeSelf == true && infoPanel.activeSelf == false)
        {
            explanatationObjects.SetActive(false);
            infoPanel.SetActive(true);
            WriteData();
        }
        else if(explanatationObjects.activeSelf == false && infoPanel.activeSelf == true)
        {
            FindObjectOfType<ExperimentDetails>().Counter = 0;
            explanatationObjects.SetActive(true);
            infoPanel.SetActive(false);
            TextToSpeech.instance.StopSpeak();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }    

    private void WriteData()
    {
        FindObjectOfType<ExperimentDetails>().WriteData();
    }
    
    
}
