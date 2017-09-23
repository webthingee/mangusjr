using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseCtrl : MonoBehaviour {

	public List<string> requestedItems = new List<string>();
    public enum ItemNames {
        Coal,
        Bark,
        Water
    }
    public ItemNames itemNames;

    void Start ()
	{
        RequestedItemsCreate();
    }

	void RequestedItemsCreate ()
	{
		CreateItem(ItemNames.Bark);
		CreateItem(ItemNames.Coal);
        //CreateItem("Oil");
        //CreateItem("Water");
    }

	void CreateItem (ItemNames _name) {
        requestedItems.Add(_name.ToString());
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
        var heroItems = GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding;   
        for (int j = 0; j < heroItems.Count; j++) {
			for (int i = 0; i < requestedItems.Count; i++) {
				if (heroItems[j].itemName == requestedItems[i]) {
					RemoveItem(requestedItems[i]);
                    
                    Destroy(heroItems[j].gameObject); 
                    heroItems.Remove(heroItems[j]);
                }
			}
		}
        InventoryScoring();
    }

    void InventoryScoring()
    {
        if (requestedItems.Count > 0) {
            Debug.Log("You Fool, That's Not Right!");
        }
        else {
            Debug.Log("You Did It");
            GameObject.Find("Game Manager").GetComponent<GameCtrl>().ScoreChange = 1;
            GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>().heroHolding.Clear();
        }
    }

}
