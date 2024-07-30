using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject finishScreen;
    private void Start()
    {
        finishScreen.SetActive(false);
    }
    void Update()
    {
   
        if (Controller.gameNumber >= 4)
        {
            finishScreen.SetActive(true);
        }
        else
        {

            finishScreen.SetActive(false);
        }

    }
}
