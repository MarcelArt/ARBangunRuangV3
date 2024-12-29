using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public TMP_InputField Field;
    public TMP_Text[] TextBoxes;
    public TMP_Text ResultTextBox;
    public TMP_Text KubusForm;

    // Start is called before the first frame update
    void Start()
    {
        KubusForm.text = "6 x s<sup>2</sup>"; 
    }

    public void CopyText()
    {
        string inputText = Field.text; // Get the text from the input field
        if (string.IsNullOrEmpty(inputText))
        {
            KubusForm.text = "6 x s<sup>2</sup>"; // Default formula with superscript
        }
        else
        {
            KubusForm.text = $"6 x {inputText}<sup>2</sup>"; // Replace "s" with the input value
        }

        foreach (TMP_Text textBox in TextBoxes)
        {
            textBox.text = inputText; // Set the text to each text box in the array
        }
    }

    public void CalculateSAKubus()
    {
        // Parse the input field value as a float
        if (float.TryParse(Field.text, out float sideLength))
        {
            // Calculate the surface area of the cube
            float surfaceArea = 6 * sideLength * sideLength;
            // Display the result in the ResultTextBox
            ResultTextBox.text = surfaceArea.ToString("F2");
        }
        else
        {
            // Handle invalid input
            ResultTextBox.text = "INVALID!";
        }
    }
}
