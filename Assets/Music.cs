using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    private AudioSource sourceBM;
    [SerializeField] private AudioClip clipBM;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        sourceBM = gameObject.AddComponent<AudioSource>();

        sourceBM.clip = clipBM;
        sourceBM.volume = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!sourceBM.isPlaying)
        {

            sourceBM.PlayScheduled(1f);
        }
    }
}
