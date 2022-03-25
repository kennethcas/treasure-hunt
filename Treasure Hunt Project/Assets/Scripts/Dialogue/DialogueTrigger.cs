using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class DialogueTrigger : MonoBehaviour
{
    private int timer;

    AudioSource interactedSound;
    AudioClip interactedSoundClip;

    [Header("Visual cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool visualCueActive;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        visualCueActive = false;

        interactedSound = GetComponent<AudioSource>();
        interactedSoundClip = interactedSound.clip;
        //Debug.Log(interactedSound.clip.length);

    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            visualCueActive = true;
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
            visualCueActive = false;
        }

        //Debug.Log("visual cue active = " + visualCueActive);

        if (playerInRange && visualCueActive==false && !interactedSound.isPlaying)
        {
            interactedSound.Play();

            timer++;
            if (timer > 2)
            {
                interactedSound.Stop();
                timer = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.F) && interactedSound.isPlaying)
        {
            interactedSound.Stop();
            Debug.Log("trying to stop interacted sound");
        }
    }

    IEnumerator interactedSoundCoroutine()
    {
        yield return new WaitForSeconds(2.08f);
        interactedSound.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
