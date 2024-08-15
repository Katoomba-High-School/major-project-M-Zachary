using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
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
        Application.Quit();

    }
}
