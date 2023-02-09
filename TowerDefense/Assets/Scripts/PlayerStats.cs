using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    public int startMoney;
    public int startLives;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
    }
}
