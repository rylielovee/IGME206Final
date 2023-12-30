using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;

public class Player : MonoBehaviour
{
    // Console so that the end scene can print score
    //public TMP_Text console;

    // List of level names in each track
    private string[][] tracks = {
        // Easy Track
        new string[] {"4thJulyEngland", "DesertQuestion", "MiddleOfAmerica", "Months28Days", "PEMDAS"},
        // Medium Track
        new string[] {"Chicago", "LettersInAlphabet", "LilyPad", "PenniesQuestion", "SmallestCircle"},
        // Hard Track
        new string[] {"Apples", "MakeEvenNumber", "SWIMS", "30centNot2Quarters", "EndOfRainbow"}
    };

    // index for each track in order of EASY, MEDIUM, HARD
    private static int[] progressMarkers = new int[] { 0, 0, 0 };

    // Current player score
    private static int points = 0;

    // Called by the level handler at the end of each level
    // Args: LevelDifficulty type => type of level completed
    //       Bool win => true if beat level
    public void EndLevel(Constants.LevelDifficulty type, bool win)
    {
        if(win)
        {
            progressMarkers[(int) type]++;

            // TODO: Calculate how points should be given out
            points += 1 + (int)type;

            Constants.LevelDifficulty newLevelType = type switch
            {
                Constants.LevelDifficulty.EASY => Constants.LevelDifficulty.MEDIUM,
                _ => Constants.LevelDifficulty.HARD,
            };
            JumpLevel(newLevelType);
        }
        else
        {
            if (Constants.LevelDifficulty.EASY == type) { EndGame(type); }
            else
            {
                // Cast as int, subtract 1, cast back to enum
                JumpLevel((Constants.LevelDifficulty)((int)type - 1));
            }
        }
    }

    // Handles starting the game, called by "Start Game" on start screen or "Try Again" on end screen
    public void StartGame()
    {
        points = 0;
        for (int i = 0; i < 3;  i++)
        {
            progressMarkers[i] = 0;
        }
        SceneManager.LoadScene(tracks[1][0]);
    }

    // Handles leaving the game on the title screen
    public void QuitGame()
    {
        Application.Quit();
    }

    // Switches to the next level difficulty 
    private void JumpLevel(Constants.LevelDifficulty type)
    {
        int index = progressMarkers[(int) type];

        if (index >= tracks[(int)type].Length)
        { // If index is greater than the track it is supposed to be on, end game
            SceneManager.LoadScene("EndScene");
            EndGame(type);
        } 
        else
        {
            // Load scene from track of given type at given index
            SceneManager.LoadScene(tracks[(int)type][index]);
        }
    }

    // Handle ending the game
    private void EndGame(Constants.LevelDifficulty type)
    {
        string endString = "";
        if (Constants.LevelDifficulty.EASY == type && progressMarkers[(int) type] < tracks[(int) type].Length) 
        {
            endString = $"You're not the brightest bulb in the chandelier, are you? You got {points} points.";
        }
        else
        {
            endString = type switch
            {
                Constants.LevelDifficulty.EASY => $"Against all odds, you made it to the end with {points} points.",
                Constants.LevelDifficulty.MEDIUM => $"You're a smart cookie, ending with {points} points.",
                Constants.LevelDifficulty.HARD => $"You're a genius! You ended with {points} points.",
            };
        }

        Debug.Log(endString);
        //console.text = endString;
    }
        
}
