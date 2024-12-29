using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimasTextUpdater : MonoBehaviour
{
    public TMP_InputField BaseLengthField; // Input field for base side length (s)
    public TMP_InputField SlantHeightField; // Input field for slant height (ℓ)
    public TMP_Text[] TextBoxes; // For displaying inputs
    public TMP_Text ResultTextBox; // Result text box
    public TMP_Text LimasForm; // Formula text box
    public TMP_Text BaseAreaTextBox; // For base area result
    public TMP_Text LateralAreaTextBox; // For lateral area result

    private string defaultLimasForm = "Lst + LA";

    void Start()
    {
        LimasForm.text = defaultLimasForm;
        BaseAreaTextBox.text = "s x s"; // Clear base area at start
        LateralAreaTextBox.text = "4 x (1/2 x s x ℓ)"; // Clear lateral area at start
    }

    void Awake()
    {
        LimasForm.text = defaultLimasForm;
        BaseAreaTextBox.text = "s x s";
        LateralAreaTextBox.text = "4 x (1/2 x s x ℓ)";
        LimasForm.ForceMeshUpdate();
    }

    public void CopyText()
    {
        if (TextBoxes.Length != 2)
        {
            return;
        }

        TextBoxes[0].text = BaseLengthField.text; // gets Base Side Length (s)
        TextBoxes[1].text = SlantHeightField.text; // gets Slant Height (ℓ)

        // Parse input values
        bool isBaseLengthValid = float.TryParse(BaseLengthField.text, out float s);
        bool isSlantHeightValid = float.TryParse(SlantHeightField.text, out float slantHeight);

        // Validate inputs
        if (!isBaseLengthValid || !isSlantHeightValid)
        {
            LimasForm.text = defaultLimasForm;
            ResultTextBox.text = "INVALID!";
            BaseAreaTextBox.text = "s x s";
            LateralAreaTextBox.text = "4 x (1/2 x s x ℓ)";
            return;
        }

        // Calculate the surface area
        float baseArea = s * s; // B = s^2 for square base
        float lateralArea = 4 * (0.5f * s * slantHeight); // 4 x (1/2 x ℓ x s)
        float surfaceArea = lateralArea + baseArea;

        // Update the formula text
        LimasForm.text = $"{baseArea} + {lateralArea}";
        ResultTextBox.text = $"{surfaceArea:F2}";

        // Update base area and lateral area texts
        BaseAreaTextBox.text = $"{s} x {s} = {baseArea:F2}";
        LateralAreaTextBox.text = $"4 x (1/2 x {s} x {slantHeight}) = {lateralArea:F2}";
    }
}
