using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    public static int rounds;
    public int startMoney;
    public int startLives;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }
}
