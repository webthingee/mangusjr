using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour {

    public Text textArea;
    public GameObject actionButton;
    public Text actionButtonText;
    public GameObject startButton;
    TextAsset phaseAsset;
    int infoPhase = 0;

    void Awake()
    {
        phaseAsset = Resources.Load("Phase_" + 1) as TextAsset;
    }

    void Start()
    {
        startButton.SetActive(false);
        actionButton.SetActive(true);
        actionButtonText.text = "Next...";
    }

    int IncreaseInfoPhase()
    {
        infoPhase += 1;

        if (infoPhase >= 5)
        {
            Debug.Log("End");
            actionButton.SetActive(false);
            startButton.SetActive(true);
            infoPhase = 4;
        }

        return infoPhase;
    }

    public void Phase_Advance()
    {
        phaseAsset = Resources.Load("Phase_" + IncreaseInfoPhase()) as TextAsset;
        textArea.text = phaseAsset.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewStartGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
