using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Takes player to game
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
    //Takes player to how to play scene
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    //Quits Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
