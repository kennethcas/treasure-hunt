using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; } //ONLY ACCESSED BY OUTSIDE SCRIPTS

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("found more than one dialogue manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //GET ALL OF THE CHOICES TEXT
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //RETURN RIGHT AWAY IF DIALOGUE ISNT PLAYING
        if (!dialogueIsPlaying)
        {
            return;
        }

        //HANDLE CONTINUING TO THE NEXT LINE IN THE DIALOGUE WHEN SUBMIT IS PRESSED
        if (InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //SET TEXT FOR THE CURRENT DIALOGUE LINE
            dialogueText.text = currentStory.Continue();
            //DISPLAY CHOICES, IF ANY, FOR THIS DIALOGUE LINE
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //DEFENSIVE CHECK TO MAKE SURE THE UI CAN SUPPORT THE NUMBER OF CHOICES COMING IN 
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given:"
                + currentChoices.Count);
        }

        int index = 0;
        //ENABLE AND INIT THE CHOICES UP TO THE AMOUNT OF CHOICES OFR THIS LINE OF DIALOGUE
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //GO THROUGH THE REMAINING CHOICES THE UI SUPPORTS AND MAKE SURE THEYRE HIDDEN
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false); 
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        //EVENT SYSTEM REQUIRES WE CLEAR IT FIRST AND THEN WAIT FOR AT LEAST 1 FRAME
        //BEFORE WE SET THE CURRENT SELECTED OBJECT
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
}
