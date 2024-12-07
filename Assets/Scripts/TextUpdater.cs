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


    // Start is called before the first frame update
    public void CopyText()
    {
        string inputText = Field.text; // Get the text from the input field

        foreach (TMP_Text textBox in TextBoxes)
        {
            textBox.text = inputText; // Set the text to each text box in the array
        }
    }

    public void CalculateSurfaceArea()
    {
        // Parse the input field value as a float
        if (float.TryParse(Field.text, out float sideLength))
        {
            // Calculate the surface area of the cube
            float surfaceArea = 6 * sideLength * sideLength;
            // Display the result in the ResultTextBox
            ResultTextBox.text = "Luasnya adalah: " + surfaceArea.ToString("F2");
        }
        else
        {
            // Handle invalid input
            ResultTextBox.text = "Tolong masukkan angka!";
        }
    }
}
