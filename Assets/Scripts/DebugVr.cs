using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugVr : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detected(string shape) {
        text.text = $"Detected: {shape}";
    }

    public void Undetected() {
        text.text = $"Undetected:";
    }
}
