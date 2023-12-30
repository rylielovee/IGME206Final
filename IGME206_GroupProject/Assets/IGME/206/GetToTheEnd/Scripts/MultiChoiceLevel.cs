using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiChoiceLevel : Level
{

    // Start is called before the first frame update
    void Start()
    {
        base.Init();
    }

    // Attach to button OnClick 
    // string choice optional for debugging purposes
    public void CorrectChoice(string choice = "")
    {
        Debug.Log($"You chose the correct answer: '{choice}'");
        base.Success();
    }

    // Attach to button OnClick
    // string choice optional for debugging purposes
    public void WrongChoice(string choice = "")
    {
        Debug.Log($"You chose the wrong answer: '{choice}'");
        base.Failure();
    }

}
