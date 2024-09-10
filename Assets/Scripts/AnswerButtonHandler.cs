using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonHandler : MonoBehaviour
{
    public AudioSource correctSound;
    public AudioSource wrongSound;

    private bool isCorrect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCorrect() {
        isCorrect = true;
    }

    public void SetWrong() {
        isCorrect = false;
    }

    public void OnPressed() {
        if (isCorrect) {
            correctSound.Play();
        } else {
            wrongSound.Play();
        }
    }
}
