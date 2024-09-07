using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeometryWithNets : MonoBehaviour
{
    public List<GameObject> netStates;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = netStates.Count - 1;
        
        for (int i = 0; i < netStates.Count; i++) {
            if (i == netStates.Count - 1) {
                netStates[i].SetActive(true);
                currentIndex = i;
            } else {
                netStates[i].SetActive(false);
            }
        } 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log(1);
                DetectTouch(touch.position);
            }
        }

        // For mouse input (PC)
        if (Input.GetMouseButtonDown(0))
        {
            DetectTouch(Input.mousePosition);
        }
    }

    private void DetectTouch(Vector2 screenPosition) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                ToggleNet();
            }
        }
    }

    private void ToggleNet() {
        netStates[currentIndex].SetActive(false);
        if (currentIndex < netStates.Count - 1) {
            currentIndex++;
        } else {
            currentIndex = 0;
        }

        netStates[currentIndex].SetActive(true);
    }
}
