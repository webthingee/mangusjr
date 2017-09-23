using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shootDelay;

    private float shootCountdown;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Shoot(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Shoot(other.gameObject);
        }

        if (this.transform.parent.tag == "Enemy" && other.tag == "Home")
        {
            this.transform.parent.GetComponent<EnemyMovement>().isMoving = false;
            Shoot(other.gameObject);
        }
    }

    void Shoot(GameObject _go)
    {
        shootCountdown -= Time.deltaTime;

        if (shootCountdown <= 0)
        {
            GameObject iBullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            iBullet.GetComponent<BulletCtrl>().FireAt(_go);
            shootCountdown = shootDelay;
        }
    }
}