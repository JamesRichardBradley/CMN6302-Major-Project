using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject fade;
    private int selection;

    // Begins a new game
    public void PlayGame()
    {
        FadeOutTo(2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(4);
    }

    // Closes the application
    public void QuitGame()
    {
        FadeOutTo(3);
    }

    // Activates trigger for Fade Out animation, then updates the Level Selection Number
    void FadeOutTo(int levelNo)
    {
        animator.SetTrigger("FadeOut");
        Debug.Log("FadeOut Triggered");
        selection = levelNo;
    }

    // Called once the Fade Out animation has completed, to then either begin the game, or close the application
    void OnFadeoutComplete()
    {
        if (selection == 2)
        {
                Debug.Log("New Game Starting");
                SceneManager.LoadScene(2);
        }
        else if (selection == 3)
        {
                Debug.Log("Application Closing");
                Application.Quit();
        }
    }
}
