using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour {

	public bool useTrigger = true;
	public bool useCollision = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && useTrigger) {
			Debug.Log("Triggered by " + this.name);
			GameObject.Find("Game Manager").GetComponent<GameCtrl>().EndGame();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        if (other.collider.tag == "Player" && useCollision) {
            Debug.Log("Collision by " + this.name);
            GameObject.Find("Game Manager").GetComponent<GameCtrl>().EndGame();
        }	
	}
}
