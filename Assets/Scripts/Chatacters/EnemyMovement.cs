using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed = 1f;

	void Start () {
		Debug.Log("test");
		
	}
	
	void Update () {
		transform.position = Vector2.MoveTowards(
			transform.position,
			Vector2.zero,
			moveSpeed * Time.deltaTime);
	}
}
