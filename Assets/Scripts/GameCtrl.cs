using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {

	public GameObject inGameCanvas;
    public GameObject HUD;

    public int scoreTotal;
    public Text scoreDisplay;

	void Start ()
	{
        inGameCanvas.SetActive(false);
        scoreTotal = 0;
        scoreDisplay.text = scoreTotal.ToString();
        Time.timeScale = 1f;
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
