using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPDatar : MonoBehaviour
{

    public GameObject [] inputFields; // Input Field

    private void Start()
    {
        ResetFields();
    }

    public void ShowKubusInput()
    {
        ResetFields();
        inputFields[0].SetActive(true);
    }

    public void ShowBalokInput()
    {
        ResetFields();
        inputFields[1].SetActive(true);
        inputFields[2].SetActive(true);
        inputFields[3].SetActive(true);
    }

    public void ResetFields()
    {
        foreach (var field in inputFields)
        {
            field.SetActive(false);
        }
    }
}
