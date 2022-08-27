using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject other;

    //Takes player to game
    public void PlayGame()
    {
        other.GetComponent<LevelChanger>().FadeToLevel(2);
    }
    //Takes player to how to play scene
    public void HowToPlay()
    {
        other.GetComponent<LevelChanger>().FadeToLevel(1);
    }
    //Quits Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
