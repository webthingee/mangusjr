using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseCtrl : MonoBehaviour {

	public List<string> requestedItems = new List<string>();
	
	void Start ()
	{
        requestedItemsCreate();
    }

	void requestedItemsCreate ()
	{
		createItem("Rock");
		createItem("Silver");
        createItem("Oil");
        createItem("Water");
    }

	void createItem (string _name) {
        requestedItems.Add(_name);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // hero enters the home base
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            InventoryDestroy();
        }
    }

	void InventoryDestroy ()
	{
		// iterate through and build a list of the items for processing.
		foreach (ItemCtrl item in GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding)
		{
            Debug.Log(item.itemName);

			foreach (string request in requestedItems)
			{
				if (item.itemName == request) {
					Debug.Log("HAZAAH");
				}
			}

            Destroy(item.gameObject);

		}

        GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding.Clear();
    }

}
