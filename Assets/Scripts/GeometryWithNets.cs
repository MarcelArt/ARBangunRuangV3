using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GeometryWithNets : MonoBehaviour
{
    public List<GameObject> netStates;
    public float rotationSpeed = 0.2f;  
    public float tapTolerationTime;
    public TextMeshProUGUI textMeshPro;

    private int currentIndex;
    private bool isDragging = false;
    private Vector2 lastTouchPosition;
    private float tapTolerationCountDown = 0;

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
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         isDragging = true;
        //         lastTouchPosition = touch.position;

        //         tapTolerationCountDown = tapTolerationTime;
        //     } else if (touch.phase == TouchPhase.Moved && isDragging) {
        //         RotateObject(touch.position);
        //         lastTouchPosition = touch.position;

        //         tapTolerationCountDown -= Time.deltaTime;
        //     } else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
        //         isDragging = false;

        //         if (tapTolerationCountDown > 0) DetectTouch(touch.position);
        //     }
        // }

        // For mouse input (PC)
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastTouchPosition = Input.mousePosition;

            tapTolerationCountDown = tapTolerationTime;
        } else if (Input.GetMouseButton(0) && isDragging) {
            RotateObject(Input.mousePosition);
            lastTouchPosition = Input.mousePosition;
            
            tapTolerationCountDown -= Time.deltaTime;
        } else if(Input.GetMouseButtonUp(0)) {
            isDragging = false;
            if (tapTolerationCountDown > 0) DetectTouch(Input.mousePosition);
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
        textMeshPro.text = $"[{currentIndex}] {netStates[currentIndex].name}";
    }

    void RotateObject(Vector2 currentTouchPosition)
    {
        Vector2 deltaPosition = currentTouchPosition - lastTouchPosition;

        // Rotate around the Y axis (horizontal movement) and X axis (vertical movement)
        float rotationX = deltaPosition.y * rotationSpeed;
        float rotationY = -deltaPosition.x * rotationSpeed;

        // Apply the rotation to the object
        transform.Rotate(Vector3.up, rotationY, Space.World);
        transform.Rotate(Vector3.right, rotationX, Space.World);
    }

}
