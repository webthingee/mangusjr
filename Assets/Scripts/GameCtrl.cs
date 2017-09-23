using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {

	public GameObject inGameCanvas;
    public GameObject HUD;
    public Text scoreDisplay;
    public Text healthDisplay;
    public Text AlsHealthDisplay;
    public Text goalDisplay;
    public int goalGoal;

    [SerializeField] int scoreTotal;
    public int Score
    {
        get { return scoreTotal; }
    }

    public int ScoreChange
    {
        set {
            scoreTotal += value;
            scoreDisplay.text = scoreTotal.ToString();
        }
    }

    [SerializeField] int goalTotal;
    public int GoalTotal
    {
        get { return goalTotal; }
    }

    public int GoalChange
    {
        set
        {
            goalTotal += value;
            goalDisplay.text = goalTotal.ToString() + " of " + goalGoal.ToString();
            if (goalTotal >= goalGoal) {
                WinGame();
            }
        }
    }

    void Start ()
	{
        inGameCanvas.SetActive(false);
        scoreTotal = ScoreChange = 0;
        goalTotal = GoalChange = 0;
        Time.timeScale = 1f;
    }

    void Update ()
    {
        // @todo this is heavy handed.
        if (GameObject.Find("MagnusJR")) {
            healthDisplay.text = GameObject.Find("MagnusJR").GetComponent<CharacterAttr>().CharHealth.ToString();
        }
        if (GameObject.Find("Albertus"))
        {
            AlsHealthDisplay.text = GameObject.Find("Albertus").GetComponent<CharacterAttr>().CharHealth.ToString();
        }
    }

	public void StartGame ()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void EndGame ()
    {
        inGameCanvas.SetActive(true);
    }

    public void WinGame ()
    {
        Debug.Log("WINNER");
        Time.timeScale = 0f;
    }
}
