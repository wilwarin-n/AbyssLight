using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Switch : MonoBehaviour
{
    public string levelN = "GameMap_2";
    public int index = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(levelN);
            SceneManager.LoadScene(index);
        }
    }


}
