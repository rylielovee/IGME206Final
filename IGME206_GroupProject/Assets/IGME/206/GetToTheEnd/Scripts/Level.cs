using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // EASY = 0, MEDIUM = 1, HARD = 2
    public int LevelDifficulty;

    // Derive player using GameObject.Find("GameManager").GetComponent<Player>();
    protected Player player;

    // Enum determining if EASY, MEDIUM, or HARD
    protected Constants.LevelDifficulty levelType;

    // Parent class initialization
    // changed from start so child classes could call
    protected void Init()
    {
        // Set Enum
        if (LevelDifficulty > 2 || LevelDifficulty < 0)
        {
            Debug.LogWarning("Level difficulty must be 0 (easy), 1 (medium), or 2 (hard)");
        }
        else
        {
            this.levelType = (Constants.LevelDifficulty)LevelDifficulty;
        }
        player = GameObject.Find("GameManager").GetComponent<Player>();
    }

    // Call player's end level with level type and true for win bool
    protected void Success()
    {
        Debug.Log("You beat the level");
        player.EndLevel(levelType, true);
    }

    // Call player's end level with level type and false for win bool
    protected void Failure()
    {
        Debug.Log("You failed to beat the level");
        player.EndLevel(levelType, false);
    }
}
