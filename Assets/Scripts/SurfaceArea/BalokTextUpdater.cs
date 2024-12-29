using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalokTextUpdater : MonoBehaviour
{
    public TMP_InputField LengthField; // Input field for length (l)
    public TMP_InputField WidthField;  // Input field for width (w)
    public TMP_InputField HeightField; // Input field for width (h)
    public TMP_Text[] TextBoxes;
    public TMP_Text ResultTextBox;
    public TMP_Text BalokForm;

    private string defaultBalokForm = "2 x [(p x l) + (p x t) + (l x t)]";
    // Start is called before the first frame update
    void Start()
    {
        BalokForm.text = defaultBalokForm;
    }

    void Awake()
    {
        BalokForm.text = defaultBalokForm;
        BalokForm.ForceMeshUpdate();
    }

    public void CopyText()
    {
        if (TextBoxes.Length != 3)
        {
            return;
        }

        TextBoxes[0].text = LengthField.text; // gets LengthField
        TextBoxes[1].text = WidthField.text;  // gets WidthField
        TextBoxes[2].text = HeightField.text; // gets HeightField

        // Parse input values
        bool isLengthValid = float.TryParse(LengthField.text, out float length);
        bool isWidthValid = float.TryParse(WidthField.text, out float width);
        bool isHeightValid = float.TryParse(HeightField.text, out float height);

        // Validate inputs
        if (!isLengthValid || !isWidthValid || !isHeightValid)
        {
            BalokForm.text = "2 x [(p x l) + (p x t) + (l x t)]";
            ResultTextBox.text = "INVALID!";
            return;
        }

        // Calculate the surface area
        float surfaceArea = 2 * (length * width + length * height + width * height);

        // Update the formula text and result
        BalokForm.text = $"2 x [({length} x {width}) + ({length} x {height}) + ({width} x {height})]";
        ResultTextBox.text = $"{surfaceArea:F2}";
    }
}
