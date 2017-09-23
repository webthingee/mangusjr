using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseCtrl : MonoBehaviour {

	public List<string> requestedItems = new List<string>();
	
	void Start ()
	{
        RequestedItemsCreate();
    }

	void RequestedItemsCreate ()
	{
		CreateItem("Rock");
		CreateItem("Silver");
        CreateItem("Oil");
        CreateItem("Water");
    }

	void CreateItem (string _name) {
        requestedItems.Add(_name);
		GameObject.Find("HUD").GetComponent<HUDCtrl>().UpdateRequestList();
	}

    void RemoveItem(string _name)
    {
        requestedItems.Remove(_name);
        GameObject.Find("HUD").GetComponent<HUDCtrl>().UpdateRequestList();
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

			for (int i = 0; i < requestedItems.Count; i++)
			{
				if (item.itemName == requestedItems[i])
                {
                    Debug.Log("Taking Away " + requestedItems[i]);
					RemoveItem(requestedItems[i]);
				}
			}

            Destroy(item.gameObject);
		}

        GameObject.Find("HUD").GetComponent<HUDCtrl>().UpdateRequestList();
        GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding.Clear();
    }

}
