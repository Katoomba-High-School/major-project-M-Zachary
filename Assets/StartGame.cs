using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
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
        SceneManager.LoadScene("MainGame");

    }
}
