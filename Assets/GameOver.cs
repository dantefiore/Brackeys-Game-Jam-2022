using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject other;

    public void TryAgain()
    {
        other.GetComponent<LevelChanger2>().FadeToLevel(2);
    }

    public void Quit()
    {
        other.GetComponent<LevelChanger2>().FadeToLevel(0);
    }
}
