using System.Collections;
using UnityEngine;

public class StateManager : MonoBehaviour 
{
    public static string state = "Menu";

    public static void GoToMenu()
    {
        state = "Menu";
    }

	public static void StartGame()
    {
        state = "Playing";
    }

    public static void GameOver()
    {
        state = "GameOver";
    }
}
