using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;
    public GameObject gameOverUI;


    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.L))
        { 
            EndGame();
        }*/

        if (gameIsOver)
            return;

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver= true;
        gameOverUI.SetActive(true);
        //Debug.Log("You dead");
    }
}
