using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemyPrefab;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    void Start () 
	{
		StartCoroutine(SpawnEnemyDude(30f));
	}
	
	IEnumerator SpawnEnemyDude (float _waitTime)
	{
		GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint1.transform.position, Quaternion.identity);
		enemy.GetComponent<CharacterAttr>().CharHealthChange = 10;
        enemy.GetComponent<CharacterAttr>().CharName = "wannagetid";

		yield return new WaitForSeconds(_waitTime);
		StartCoroutine(SpawnEnemyDude(30f));
    }
}
