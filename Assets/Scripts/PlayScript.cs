using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public int LevelLoad = 3;

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuStart()
    {
        SceneManager.LoadScene(0);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(2);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           SceneManager.LoadScene(LevelLoad);
        }
    }
}
