using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHolding : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (GetComponent<BasicMovement>().enabled != true) {
			AddItem();
        	PositionItem();
        	EnableItem();		
		}
	}

    void AddItem ()
    {
        transform.parent = GameObject.Find("Hero Holding").transform;
	}

    void PositionItem()
    {
        Transform lastMember = GameObject.Find("Hero Holding").transform.GetChild(transform.childCount - 1);
		transform.position = lastMember.position;
    }

    void EnableItem()
    {
        GetComponent<BasicMovement>().enabled = true;
	}
}