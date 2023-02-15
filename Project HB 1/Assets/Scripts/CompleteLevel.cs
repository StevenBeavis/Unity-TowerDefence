using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public string menu = "MainMenu";
    public Fade f;

    public void Menu()
    {
        f.FadeT(menu);
    }
}
