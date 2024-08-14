using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnButtonPress()
    {
        Controller.gameNumber = 0;
        CanvasManager.driftTime = 0;
        CanvasManager.driftTime2 = 0;
        CanvasManager.drifting = false;
        CanvasManager.speed = 0;
        CanvasManager.checkPoints = 0;

        SceneManager.LoadScene("MainMenu");

    }
}
