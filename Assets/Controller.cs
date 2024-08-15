using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;

    private string gameState = "3";
    public static int gameNumber = 0;
    private float gameTimer = 0;
    private AudioSource sourceBeep;
    [SerializeField] private AudioClip clipBeep;
    private AudioSource sourceBeep2;
    [SerializeField] private AudioClip clipBeep2;

    private void Start()
    {
        sourceBeep2 = gameObject.AddComponent<AudioSource>();

        sourceBeep2.clip = clipBeep2;
        sourceBeep = gameObject.AddComponent<AudioSource>();

        sourceBeep.clip = clipBeep;
        sourceBeep.PlayScheduled(1f);
        
    }


    void Update()
    {
        gameTimer += Time.deltaTime;
        timerObject.text = gameState;

        if (Input.GetKey(KeyCode.Escape))
        {
            Controller.gameNumber = 0;
            CanvasManager.driftTime = 0;
            CanvasManager.driftTime2 = 0;
            CanvasManager.drifting = false;
            CanvasManager.speed = 0;
            CanvasManager.checkPoints = 0;

            SceneManager.LoadScene("MainMenu");
        }


        if (gameNumber == 0 && gameTimer >= 1)
        {
            sourceBeep.PlayScheduled(1f);
            gameState = "2";
            gameTimer = 0;
            gameNumber++;
        }
        else if (gameNumber == 1 && gameTimer >= 1)
        {
            sourceBeep.PlayScheduled(1f);
            gameState = "1";
            gameTimer = 0;
            gameNumber++;
        }
        else if (gameNumber == 2 && gameTimer >= 1)
        {
            sourceBeep2.PlayScheduled(1f);
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
