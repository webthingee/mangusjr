using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {

	public GameObject inGameCanvas;

	void Start ()
	{
        inGameCanvas.SetActive(false);
    }

	public void StartGame ()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
	}

    public void EndGame()
    {
        inGameCanvas.SetActive(true);
    }
}
