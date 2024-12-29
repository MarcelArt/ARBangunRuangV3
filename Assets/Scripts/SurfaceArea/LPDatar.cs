using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LPDatar : MonoBehaviour
{

    public GameObject[] inputFields; // Input Field
    public GameObject[] images;
    public GameObject[] buttons;     // Buttons to display
    public TMP_Text[] formTexts;


    private void Start()
    {
        ResetFields();
        ResetImages();
        ResetButtons();
        ResetTextsform();
    }

    public void ShowKubusInput()
    {
        ResetFields();
        ResetImages();
        ResetButtons();
        ResetTextsform();
        inputFields[0].SetActive(true);
        images[0].SetActive(true);
        buttons[0].SetActive(true);  // Display the button for Kubus
        formTexts[0].gameObject.SetActive(true);
        formTexts[1].gameObject.SetActive(true);
        formTexts[0].text = "\"6 x s<sup>2</sup>";
    }

    public void ShowBalokInput()
    {
        ResetFields();
        ResetImages();
        ResetButtons();
        ResetTextsform();
        inputFields[1].SetActive(true);
        inputFields[2].SetActive(true);
        inputFields[3].SetActive(true);
        images[1].SetActive(true);
        buttons[1].SetActive(true);  // Display the button for Balok
        formTexts[2].gameObject.SetActive(true);
        formTexts[3].gameObject.SetActive(true);
        formTexts[2].text = "2 x [(p x l) + (p x t) + (l x t)]";
    }

    public void ShowLimasInput()
    {
        ResetFields();
        ResetImages();
        ResetButtons();
        ResetTextsform();
        inputFields[4].SetActive(true);
        inputFields[5].SetActive(true);
        images[2].SetActive(true);
        buttons[2].SetActive(true);
        formTexts[4].gameObject.SetActive(true);
        formTexts[5].gameObject.SetActive(true);
        formTexts[6].gameObject.SetActive(true);
        formTexts[7].gameObject.SetActive(true);
        formTexts[4].text = "4 x (1/2 x s x ℓ)";
        formTexts[5].text = "s x s";
        formTexts[6].text = "LsT + LA";
    }

    public void ShowPrismaInput()
    {
        ResetFields();
        ResetImages();
        ResetButtons();
        ResetTextsform();
        inputFields[6].SetActive(true);
        inputFields[7].SetActive(true);
        inputFields[8].SetActive(true);
        inputFields[9].SetActive(true);
        inputFields[10].SetActive(true);
        images[3].SetActive(true);
        buttons[3].SetActive(true);
        formTexts[8].gameObject.SetActive(true);
        formTexts[9].gameObject.SetActive(true);
        formTexts[10].gameObject.SetActive(true);
        formTexts[11].gameObject.SetActive(true);
        formTexts[8].text = "s1 + s2 + s3";
        formTexts[9].text = "1/2 x (s1 x ts)";
        formTexts[10].text = "2 x LA + (KA x tPr)";
    }

    public void ResetFields()
    {
        foreach (var field in inputFields)
        {
            field.SetActive(false);
        }

    }
    public void ResetImages()
    {
        foreach (var img in images)
        {
            img.SetActive(false);
        }
    }
    public void ResetButtons()
    {
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
    }
    public void ResetTextsform()
    {
        foreach (var text in formTexts)
        {
            if (text != null)
            {
                text.gameObject.SetActive(false);
                text.text = string.Empty;
            }
        }
    }
}
