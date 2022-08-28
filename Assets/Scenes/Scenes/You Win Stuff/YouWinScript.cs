using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScript : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void toCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
