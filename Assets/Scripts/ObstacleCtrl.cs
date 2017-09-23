using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log("Game Over");
			GameObject.Find("Game Manager").GetComponent<GameCtrl>().EndGame();
		}
	}
}
