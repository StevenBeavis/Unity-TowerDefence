using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pau;

    public string menuScene = "MainMenu";

    public Fade Fader;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Pause();
        }
    }

    public void Pause()
    {
        pau.SetActive(!pau.activeSelf);

        if (pau.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else 
        {
            Time.timeScale = 1f;
        }
    
    }

    public void Restart()
    {
        Pause();

        Fader.FadeT(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Pause();
        Fader.FadeT(menuScene);

    }
}
