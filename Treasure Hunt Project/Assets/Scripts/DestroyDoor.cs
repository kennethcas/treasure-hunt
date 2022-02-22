using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory.isFull[2] == true)
            {
                Debug.Log("Inventory is full");
                Destroy(gameObject);
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("door is being collided with");
        if (inventory.isFull[2] == true)
        {
            Destroy(gameObject);
        }
      
    }
}
