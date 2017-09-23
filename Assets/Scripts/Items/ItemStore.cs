using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStore : MonoBehaviour {

    public GameObject itemToAdd;
	public GameObject itemSprite;
	public string giveItemName;
    GameObject hh;

    void Awake ()
    {
        hh = GameObject.Find("Hero Holding");
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(hh.transform.childCount - 1);
            //AddItem();
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player") {
            AddItem();
        }
    }

    void AddItem ()
    {
        // find last member to attach to
        Transform lastMember = hh.transform.GetChild(hh.transform.childCount - 1);
        // attach item
        GameObject item = (GameObject) Instantiate(itemToAdd, lastMember.position, Quaternion.identity, hh.transform);
        item.GetComponent<ItemCtrl>().itemName = giveItemName;
		item.name = giveItemName;
        // attach sprite
        GameObject itemsprite = (GameObject)Instantiate(itemSprite, item.transform.position, Quaternion.identity, item.transform);
        // add to holding list
        hh.GetComponent<HeroHoldingCtrl>().heroHolding.Add(item.GetComponent<ItemCtrl>());
    }
}
