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
        // Periksa apakah target Kubus aktif
        if (kubusTarget.activeInHierarchy)
        {
            ShowKubusInput();
        }
        // Periksa apakah target Balok aktif
        else if (LimasTarget.activeInHierarchy)
        {
            ShowBalokInput();
        }
        // Jika tidak ada target yang aktif
        else
        {
            ResetFields();
        }
    }

    void ShowKubusInput()
    {
        ResetFields();
        inputFieldA.SetActive(true); // Hanya aktifkan inputFieldA
    }

    void ShowBalokInput()
    {
        ResetFields();
        inputFieldB.SetActive(true);
        inputFieldC.SetActive(true);
        inputFieldD.SetActive(true);
    }

    void ResetFields()
    {
        inputFieldA.SetActive(false);
        inputFieldB.SetActive(false);
        inputFieldC.SetActive(false);
        inputFieldD.SetActive(false);
    }
}