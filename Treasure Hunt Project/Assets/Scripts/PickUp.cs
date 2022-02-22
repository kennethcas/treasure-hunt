using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
   // public int keyCounter = 0;

   // private bool endingTrigger = false;
   // public GameObject door;

    private void Start()
    {
       // Instantiate(door);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //ITEM CAN BE ADDED TO INVENTORY

                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                   // keyCounter++;
                    //bleepSource.Play(); 
                    break;
                }
            }
        }
       
    }

    void Update()
    {
       //if (keyCounter == 3){
       //     endingTrigger = true;
       // }

      // if (endingTrigger == true)
      //  {
      //      Destroy(door);
       // }
    }
   

}
