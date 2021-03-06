﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shootDelay;
    public GameObject target;

    [SerializeField] float shootCountdown;

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

        if (this.tag == "EnemyBullet" && other.tag == "Home")
        {
            //Debug.Log(other.name);
            Shoot(other.gameObject);
        }

        target = other.gameObject;
    }

    public void Shoot(GameObject _go)
    {
        shootCountdown -= Time.deltaTime;

        if (shootCountdown <= 0)
        {
            GameObject iBullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            iBullet.tag = this.tag;
            iBullet.GetComponent<BulletCtrl>().FireAt(_go);
            shootCountdown = shootDelay;
        }
    }
}