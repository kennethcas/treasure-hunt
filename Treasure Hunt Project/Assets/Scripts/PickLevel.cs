using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickLevel : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void GoToLevelOne()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene("Main 2");
    }

    public void GoToLevelThree()
    {
        SceneManager.LoadScene("Main 3");
    }

    public void GoToSelectScreen()
    {
        SceneManager.LoadScene("SelectScreen");
    }
   
}
