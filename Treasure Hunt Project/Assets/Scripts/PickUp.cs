using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

   // public AudioSource bleepSource;
    //private bool soundCanBePlayed;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //bleepSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            //bleepSource.Play();
           // Debug.Log("pick up object colliding with player");
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //ITEM CAN BE ADDED TO INVENTORY

                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    //bleepSource.Play(); 
                    break;
                }
            }
        }
        /*
        if (inventory.isFull[0] == false)
        {
            soundCanBePlayed = true;
        }

        else if (inventory.isFull[1] == false)
        {
            soundCanBePlayed = true;
        }

        else if (inventory.isFull[2] == false)
        {
            soundCanBePlayed = true;
        }
        else if (inventory.isFull[0] == true && inventory.isFull[1] == true && inventory.isFull[2] == true)
        {
            soundCanBePlayed = false;
        }
        */
    }

    void Update()
    {
        /*
        if (soundCanBePlayed == true)
        {
            soundCanBePlayed = false;
            PlaySound();
        }
        */
    }
    /*
    void PlaySound()
    {
        bleepSource.Play();
    }
    
    void Awake()
    {
        bleepSource.Play();
    }
    */

}
