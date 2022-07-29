using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManagment : MonoBehaviour
{
    private GameObject pauseUI, defaultUI, systemUI, planetUI, missionUI;
    private int uiMode, previousUIMode;
    public Animator animator;
    public bool paused = false;

    // Start is called before the first frame update
    private void Start()
    {
        GetUiElements();
        SetUIMode(0);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if (uiMode != 4)
            {
                previousUIMode = uiMode;
                SetUIMode(4);
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                SetUIMode(previousUIMode);
                Time.timeScale = 1;
                paused = false;
            }
        }

        if (uiMode == 2)
        {
            if (Input.GetButtonDown("Submit"))
            {
                animator.SetTrigger("FadeOutTrigger");
            }
        }
    }

    void GetUiElements()
    {
        pauseUI = GameObject.Find("Pause Menu");
        defaultUI = GameObject.Find("Default");
        systemUI = GameObject.Find("System View Buttons");
        planetUI = GameObject.Find("Planet View Buttons");
        missionUI = GameObject.Find("Mission Planet Buttons");
    }

    public void SetUIMode(int selection)
    {
        uiMode = selection;
        switch (uiMode)
        {
            case 0:
                pauseUI.SetActive(false);
                defaultUI.SetActive(true);
                systemUI.SetActive(false);
                planetUI.SetActive(false);
                missionUI.SetActive(false);
                break;

            case 1:
                pauseUI.SetActive(false);
                defaultUI.SetActive(false);
                systemUI.SetActive(true);
                planetUI.SetActive(false);
                missionUI.SetActive(false);
                break;

            case 2:
                pauseUI.SetActive(false);
                defaultUI.SetActive(false);
                systemUI.SetActive(false);
                planetUI.SetActive(false);
                missionUI.SetActive(true);
                break;

            case 3:
                pauseUI.SetActive(false);
                defaultUI.SetActive(false);
                systemUI.SetActive(false);
                planetUI.SetActive(true);
                missionUI.SetActive(false);
                break;

            case 4:
                pauseUI.SetActive(true);
                defaultUI.SetActive(false);
                systemUI.SetActive(false);
                planetUI.SetActive(false);
                missionUI.SetActive(false);
                break;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(3);
    }
}
