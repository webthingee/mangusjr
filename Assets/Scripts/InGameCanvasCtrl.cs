using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvasCtrl : MonoBehaviour {

	public Text message;
    public bool start = true;
    public bool dead;

    void OnEnable () {
		Time.timeScale = 0f;

		if (start) {
			message.text =
			"Welcome! \n" +
			"Al will tell you what he needs so he can transform the blades of grass" +
			" into the gold you need." +
			" Why do you need gold? \n" +
			"That's a long story... let me tell you along the way...";

			start = false;
		}

		if (dead) {
			message.text =
		 	"Today you did not succeed.But this is a video game, so you get to try again.";
		}
	}
	
	void OnDisable()
	{
        Time.timeScale = 1f;
    }

}
