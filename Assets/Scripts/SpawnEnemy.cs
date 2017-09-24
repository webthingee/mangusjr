using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemyPrefab;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    void Start () 
	{
		StartCoroutine(SpawnEnemyDude(Random.Range(30f, 50f)));
	}
	
	IEnumerator SpawnEnemyDude (float _waitTime)
	{
		Vector2 spawnLoc;
		int _location = Random.Range(0, 2);
		
		if (_location > 0) {
			spawnLoc = spawnPoint1.transform.position;
		}
		else {
            spawnLoc = spawnPoint2.transform.position;
        }

		GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnLoc, Quaternion.identity);
		enemy.GetComponent<CharacterAttr>().CharHealthChange = 9;
        enemy.GetComponent<CharacterAttr>().CharName = "wannagetid";

		yield return new WaitForSeconds(_waitTime);
		StartCoroutine(SpawnEnemyDude(Random.Range(30f, 50f)));
    }
}
