using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseCtrl : MonoBehaviour {

	public List<ItemCtrl> requestedItems = new List<ItemCtrl>();
	
	
	void Start ()
	{
        requestedItemsCreate();

    }

	void OnTriggerEnter2D( Collider2D other)
	{
		// hero enters the home base
		if (other.tag == "Player") {
			Debug.Log(other.name);
			InventoryDestroy();
		}
	}

	void requestedItemsCreate ()
	{
		createItem("Rock");
		createItem("Silver");
        createItem("Oil");
        createItem("Water");
    }

	void createItem (string _name) {
		ItemCtrl type = gameObject.AddComponent(typeof(ItemCtrl)) as ItemCtrl;
        type.itemName = _name;
        requestedItems.Add(type);
	}

	void InventoryDestroy ()
	{
		// iterate through and build a list of the items for processing.
		foreach (ItemCtrl item in GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding)
		{
            Debug.Log(item.itemName);

			foreach (ItemCtrl request in requestedItems)
			{
				if (item.itemName == request.itemName) {
					Debug.Log("HAZAAH");
				}
			}

            Destroy(item.gameObject);

		}

        GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding.Clear();
    }
}
