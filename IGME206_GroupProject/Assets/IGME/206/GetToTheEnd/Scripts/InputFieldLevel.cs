using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// This script should be attatched to the canvas
public class InputFieldLevel : Level
{
    public string Answer;

    // Derive this field
    private TMP_InputField inputField;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();

        if (inputField != null) { Debug.Log("Input set"); }
        if (Answer != null) { Debug.Log($"The set answer is '{Answer}'"); }
        base.Init();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)) {
            CheckAnswer();
        }
    }

    private void CheckAnswer()
    {
        Debug.Log($"Input was '{inputField.text}'");
        Debug.Log($"Trying '{inputField.text.ToString()}' == '{Answer.ToString()}'");

        // Compare without whitespace or case sensitivity 
        if (Answer.Trim().ToLower().Equals(inputField.text.Trim().ToLower()))
        {
            base.Success();
        } 
        else
        {
            base.Failure();
        }
    }
}
