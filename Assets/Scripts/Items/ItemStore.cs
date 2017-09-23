﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStore : MonoBehaviour {

    public GameObject itemToAdd;
	public GameObject itemSprite;
	public string giveItemName;
    GameObject hh;

    void Awake()
    {
        hh = GameObject.Find("Hero Holding");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(hh.transform.childCount - 1);
            //AddItem();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AddItem();
        }
    }

    void AddItem()
    {
        Transform lastMember = hh.transform.GetChild(hh.transform.childCount - 1);

        GameObject item = (GameObject) Instantiate(itemToAdd, lastMember.position, Quaternion.identity, hh.transform);
        item.GetComponent<ItemCtrl>().itemName = giveItemName;
		item.name = giveItemName;
        GameObject itemsprite = (GameObject)Instantiate(itemSprite, item.transform.position, Quaternion.identity, item.transform);

    }
}
