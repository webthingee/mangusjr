using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public bool isMoving = true;
	
	void Update () {
		if (isMoving) {
			transform.position = Vector2.MoveTowards(
				transform.position,
				GameObject.Find("Home Base").GetComponent<Transform>().position,
				moveSpeed * Time.deltaTime
			);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        isMoving = false;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isMoving = true;
    }
}
