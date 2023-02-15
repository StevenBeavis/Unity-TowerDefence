using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //personal
    public static int Money;
    public int startMoney = 300;
    public static int Lives;
    public int startLives = 5;
    public static int rounds;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        rounds = 0;
    }

}
