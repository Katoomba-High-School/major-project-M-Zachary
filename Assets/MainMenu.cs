using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource sourceBeep;
    [SerializeField] private AudioClip clipBeep;

    private void Start()
    {
        sourceBeep = gameObject.AddComponent<AudioSource>();

        sourceBeep.clip = clipBeep;

    }
    public void OnButtonPress()
    {
        sourceBeep.PlayScheduled(1f);
        Controller.gameNumber = 0;
        CanvasManager.driftTime = 0;
        CanvasManager.driftTime2 = 0;
        CanvasManager.drifting = false;
        CanvasManager.speed = 0;
        CanvasManager.checkPoints = 0;

        SceneManager.LoadScene("MainMenu");

    }
}
