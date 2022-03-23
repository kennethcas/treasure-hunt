using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public bool narrationIsPlaying { get; private set; }

    private static Dialogue instance;

    void Start()
    {
        StartCoroutine(Type());
        narrationIsPlaying = true;
    }

    void Update()
    {
        Debug.Log(narrationIsPlaying);
        if (!narrationIsPlaying)
        {
            return;
        }

        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public static Dialogue GetInstance()
    {
        return instance;
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            narrationIsPlaying=false;
            
        }
    }
}
