
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger2 : MonoBehaviour
{
    public Animator animator;
    
    private int levelToLoad;

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
