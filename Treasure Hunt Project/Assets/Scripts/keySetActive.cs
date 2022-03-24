using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class keySetActive : MonoBehaviour
{
    //private bool interactedWithNPC;

    private void Awake()
    {
        //interactedWithNPC = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (PlayerMovement.GetInstance().interactedWithGhostNPC)
        {
            gameObject.SetActive(true);
        }
    }
}
