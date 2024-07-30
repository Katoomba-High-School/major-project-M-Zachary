using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;

    private string gameState = "3";
    public static int gameNumber = 0;
    private float gameTimer = 0;

  

    void Update()
    {
        gameTimer += Time.deltaTime;
        timerObject.text = gameState;
   

        if (gameNumber == 0 && gameTimer >= 1)
        {
            gameState = "2";
            gameTimer = 0;
            gameNumber++;
        }
        else if (gameNumber == 1 && gameTimer >= 1)
        {
            gameState = "1";
            gameTimer = 0;
            gameNumber++;
        }
        else if (gameNumber == 2 && gameTimer >= 1)
        {
            gameState = "Go";
            gameTimer = 0;
            gameNumber++;
        }
        else if (gameNumber == 3 && gameTimer >= 1)
        {
            if (way.Que.Count <= 0)
            {
                gameState = "Complete";
                gameTimer = 0;
                gameNumber++;
            }
            else
            {
                gameState = "";
            }


        }
        else if (gameNumber == 4 && gameTimer >= 1)
        {
            gameState = "";
        }

    }
}
