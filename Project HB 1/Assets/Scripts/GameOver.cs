using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public string menuScene = "MainMenu";
    public Fade f;

    void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        f.FadeT(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        
        f.FadeT(menuScene);

    }


}
