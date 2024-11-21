using UnityEngine;

public class TextColorManager : MonoBehaviour
{
    public Color textColor; // Set this color in the Inspector for each scene

    private void Start()
    {
        // Find all TMP text objects and change their color
        var textObjects = FindObjectsOfType<TMPro.TMP_Text>();
        foreach (var text in textObjects)
        {
            text.color = textColor;
        }
    }
}
