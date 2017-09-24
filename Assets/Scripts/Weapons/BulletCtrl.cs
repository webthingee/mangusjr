using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

    public float moveSpeed = 2f;
    public int bulletDamage = 2;
    private GameObject target;
    private Vector3 vDirection;

    public void FireAt(GameObject _go)
    {
        target = _go;
    }

    void Update()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                moveSpeed * Time.deltaTime
            );

            if (transform.position == target.transform.position)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Enemy" && this.tag == "HeroBullet")
        {
            other.gameObject.GetComponent<CharacterAttr>().RemoveharHealth(1);
        }
        if (other.tag == "Player" && this.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<CharacterAttr>().RemoveharHealth(1);
        }
        if (other.tag == "Home" && this.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<CharacterAttr>().RemoveharHealth(1);
        }
    }

}