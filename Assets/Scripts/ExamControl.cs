using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamControl : MonoBehaviour
{
    public GameObject HeartbeatRateMenu;
    public GameObject RespiratoryRateMenu;
    public GameObject BloodPresureMenu;
    public GameObject AbsInspectionMenu;
    public GameObject AbsPalpationMenu;
    public GameObject GenitalInspectionMenu;
    public GameObject RectalExaminationMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (HeartbeatRateMenu.activeInHierarchy == false)
            {
                HeartbeatRateMenu.SetActive(true);
            } else
            {
                HeartbeatRateMenu.SetActive(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (RespiratoryRateMenu.activeInHierarchy == false)
            {
                RespiratoryRateMenu.SetActive(true);
            }
            else
            {
                RespiratoryRateMenu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (BloodPresureMenu.activeInHierarchy == false)
            {
                BloodPresureMenu.SetActive(true);
            }
            else
            {
                BloodPresureMenu.SetActive(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (AbsInspectionMenu.activeInHierarchy == false)
            {
                AbsInspectionMenu.SetActive(true);
            } else
            {
                AbsInspectionMenu.SetActive(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (AbsPalpationMenu.activeInHierarchy == false)
            {
                AbsPalpationMenu.SetActive(true);
            }
            else
            {
                AbsPalpationMenu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GenitalInspectionMenu.activeInHierarchy == false)
            {
                GenitalInspectionMenu.SetActive(true);
            }
            else
            {
                GenitalInspectionMenu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (RectalExaminationMenu.activeInHierarchy == false)
            {
                RectalExaminationMenu.SetActive(true);
            }
            else
            {
                RectalExaminationMenu.SetActive(false);
            }
        }
    }
}
