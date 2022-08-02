using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManagment : MonoBehaviour
{
    private GameObject pauseUI, defaultUI, systemUI, planetUI, missionUI, planetsideUI;
    public Text scoreText;
    public int uiMode, previousUIMode, scoreValue;
    public Animator animator;
    public bool paused = false;

    PlayerMovementScript player;

    // Start is called before the first frame update
    private void Start()
    {
        GetUiElements();
        SetUIMode(0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
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

        if (uiMode == 5)
        {
            scoreText.text = "Anomalies Collected: " + scoreValue.ToString() + " / 8";
        }
    }

    void GetUiElements()
    {
        pauseUI = GameObject.Find("Pause Menu");
        defaultUI = GameObject.Find("Default");
        systemUI = GameObject.Find("System View Buttons");
        planetUI = GameObject.Find("Planet View Buttons");
        missionUI = GameObject.Find("Mission Planet Buttons");
        planetsideUI = GameObject.Find("Planet Surface");
    }

    void ZeroUI()
    {
        pauseUI.SetActive(false);
        defaultUI.SetActive(false);
        systemUI.SetActive(false);
        planetUI.SetActive(false);
        missionUI.SetActive(false);
        planetsideUI.SetActive(false);
    }

    public void SetUIMode(int selection)
    {
        uiMode = selection;

        Debug.Log("UI Mode: " + uiMode);

        ZeroUI();

        switch (uiMode)
        {
            case 0:
                defaultUI.SetActive(true);
                break;

            case 1:
                systemUI.SetActive(true);
                break;

            case 2:
                missionUI.SetActive(true);
                break;

            case 3:
                planetUI.SetActive(true);
                break;

            case 4:
                pauseUI.SetActive(true);
                break;

            case 5:
                planetsideUI.SetActive(true);
                break;
        }
    }
}