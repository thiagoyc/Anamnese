using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject StartRecordingMenu;
    public GameObject StopRecordingMenu;

    private void Update () {

        if (Input.GetKeyDown(KeyCode.M))
        {
            StartRecordingTrigger();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopRecordingTrigger();
        }
        
    }

    public void StartRecordingTrigger() 
    {
        if (StartRecordingMenu.activeInHierarchy == false)
        {
            StartRecordingMenu.SetActive(true);
        }
        else
        {
            StartRecordingMenu.SetActive(false);
        }
    }

    public void StopRecordingTrigger()
    {
        if (StopRecordingMenu.activeInHierarchy == false)
        {
            StopRecordingMenu.SetActive(true);
        }
        else
        {
            StopRecordingMenu.SetActive(false);
        }
    }
}
