using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        int index = Random.Range(1, 4);
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
   
}
