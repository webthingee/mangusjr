using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHolding : MonoBehaviour
{
	GameObject hh;

	void Awake()
	{
		hh = GameObject.Find("Hero Holding");	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GetComponent<BasicMovement>().enabled != true) {
			AddItem();
        	PositionItem();
        	EnableItem();		
		}
	}

    void AddItem ()
    {
        transform.parent = hh.transform;
		hh.GetComponent<HeroHoldingCtrl>().heroHolding.Add(this.GetComponent<ItemCtrl>());
	}

    void PositionItem()
    {
        Transform lastMember = hh.transform.GetChild(transform.childCount - 1);
		transform.position = lastMember.position;
    }

    void EnableItem()
    {
        GetComponent<BasicMovement>().enabled = true;
	}
}