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
    
    void Start ()
	{
        inGameCanvas.SetActive(false);
        scoreTotal = ScoreChange = 0;
        Time.timeScale = 1f;
    }

    void Update ()
    {
        // @todo this is heavy handed.
        healthDisplay.text = GameObject.Find("MagnusJR").GetComponent<CharacterAttr>().CharHealth.ToString();
    }

	public void StartGame ()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void EndGame ()
    {
        inGameCanvas.SetActive(true);
    }
}
