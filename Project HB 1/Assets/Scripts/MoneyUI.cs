using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    //personal
    public Text cash;
    // Update is called once per frame
    void Update()
    {
        cash.text ="£" + PlayerStats.Money.ToString();
    }
}
