using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NamedGeometry : MonoBehaviour
{
    public TextMeshProUGUI geometryNameText;
    public string geometryName;
    public float fadeRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectTouch();
    }

    private void DetectTouch() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    geometryNameText.text = geometryName;
                    StartCoroutine(FadeOut());
                }
            }
        }
    }

    private IEnumerator FadeOut() {
        geometryNameText.color = new Color(geometryNameText.color.r, geometryNameText.color.g, geometryNameText.color.b, 1);
        while (geometryNameText.color.a > 0f) {
            geometryNameText.color = new Color(geometryNameText.color.r, geometryNameText.color.g, geometryNameText.color.b, geometryNameText.color.a - (Time.deltaTime / fadeRate));
            yield return null;
        }
    }
}
