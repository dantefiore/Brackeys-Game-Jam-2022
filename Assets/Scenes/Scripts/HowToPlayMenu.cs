using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayMenu : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
