using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrismTextUpdater : MonoBehaviour
{
    // Input fields for triangle sides, triangle height, and prism height
    public TMP_InputField Side1Field;       // Sisi segitiga 1 (a)
    public TMP_InputField Side2Field;       // Sisi segitiga 2 (b)
    public TMP_InputField Side3Field;       // Sisi segitiga 3 (c)
    public TMP_InputField TriangleHeightField; // Tinggi segitiga (t)
    public TMP_InputField PrismHeightField;    // Tinggi prisma (h)

    // Text fields for displaying results
    public TMP_Text[] TextBoxes;
    public TMP_Text PerimeterTextBox;     // KLL 
    public TMP_Text BaseAreaTextBox;        // Luas alas segitiga (B)
    public TMP_Text PrismaForm;             // Formula display
    public TMP_Text ResultTextBox;

    private string defaultPrismaForm = "2 x LA + (KA x tPr)";
    // Start is called before the first frame update
    void Start()
    {
        PrismaForm.text = defaultPrismaForm;
        PerimeterTextBox.text = "s1 + s2 + s3";
        BaseAreaTextBox.text = "1/2 x (s1 x ts)";
    }
    public void CopyText()
    {
        if (TextBoxes.Length != 5)
        {
            return;
        }

        // Salin teks input ke TextBoxes
        TextBoxes[0].text = Side1Field.text;
        TextBoxes[1].text = Side2Field.text;
        TextBoxes[2].text = Side3Field.text;
        TextBoxes[3].text = TriangleHeightField.text;
        TextBoxes[4].text = PrismHeightField.text;

        // Hitung luas permukaan setelah menyalin teks
        CalculatePrismSurfaceArea();
    }
    public void CalculatePrismSurfaceArea()
    {
        // Parse input values
        bool isSide1Valid = float.TryParse(Side1Field.text, out float side1);
        bool isSide2Valid = float.TryParse(Side2Field.text, out float side2);
        bool isSide3Valid = float.TryParse(Side3Field.text, out float side3);
        bool isTriangleHeightValid = float.TryParse(TriangleHeightField.text, out float triangleHeight);
        bool isPrismHeightValid = float.TryParse(PrismHeightField.text, out float prismHeight);

        // Validate inputs
        if (!isSide1Valid || !isSide2Valid || !isSide3Valid || !isTriangleHeightValid || !isPrismHeightValid)
        {
            PrismaForm.text = defaultPrismaForm;
            PerimeterTextBox.text = "s1 + s2 + s3";
            BaseAreaTextBox.text = "1/2 x (s1 x ts)";
            return;
        }

        // 1. Hitung keliling alas segitiga (P = a + b + c)
        float perimeter = side1 + side2 + side3;

        // 2. Hitung luas alas segitiga (B = 0.5 * alas * tinggi segitiga)
        float baseArea = 0.5f * side1 * triangleHeight;

        // 3. Hitung luas sisi tegak prisma (L = h * P)
        float lateralArea = prismHeight * perimeter;

        // 4. Hitung total luas permukaan prisma (T = L + 2B)
        float totalSurfaceArea = lateralArea + (2 * baseArea);

        // Update formula display and result texts
        PrismaForm.text = $"2 x {baseArea} + ({perimeter} x {prismHeight})";
        PerimeterTextBox.text = $"{side1} + {side2} + {side3} = {perimeter:F2}";
        BaseAreaTextBox.text = $"1/2 x ({side1} x {triangleHeight}) = {baseArea:F2}";
        ResultTextBox.text = $"{totalSurfaceArea:F2}";
    }
}
