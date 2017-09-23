﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public bool isMoving = true;
	
	void Update () {
		if (isMoving) {
			transform.position = Vector2.MoveTowards(
				transform.position,
				Vector2.zero,
				moveSpeed * Time.deltaTime
			);
		}
	}
}