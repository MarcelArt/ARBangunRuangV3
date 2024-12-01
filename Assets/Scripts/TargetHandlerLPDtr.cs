using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandlerLPDtr : MonoBehaviour
{
    public GameObject kubusTarget; // GameObject untuk target Kubus
    public GameObject LimasTarget; // GameObject untuk target Balok

    public GameObject inputFieldA; // Input Field untuk Kubus
    public GameObject inputFieldB; // Input Field untuk Balok
    public GameObject inputFieldC;
    public GameObject inputFieldD;

    void Update()
    {
    
    }

    private void Start()
    {
        ResetFields();
    }

    public void ShowKubusInput()
    {
        ResetFields();
        inputFieldA.SetActive(true); // Hanya aktifkan inputFieldA
    }

    public void ShowBalokInput()
    {
        ResetFields();
        inputFieldB.SetActive(true);
        inputFieldC.SetActive(true);
        inputFieldD.SetActive(true);
    }

    public void ResetFields()
    {
        inputFieldA.SetActive(false);
        inputFieldB.SetActive(false);
        inputFieldC.SetActive(false);
        inputFieldD.SetActive(false);
    }
}