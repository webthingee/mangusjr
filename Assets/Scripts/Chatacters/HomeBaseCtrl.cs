using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseCtrl : MonoBehaviour {

	public List<string> requestedItems = new List<string>();
    GameCtrl gameCtrl;
    HeroHoldingCtrl hhCtrl;

    void Awake ()
    {
        gameCtrl = GameObject.Find("Game Manager").GetComponent<GameCtrl>();
        hhCtrl = GameObject.Find("Hero Holding").GetComponent<HeroHoldingCtrl>();
    }
    void Start ()
	{
        CreateRequestItemsList(2);
    }

	void CreateRequestItemsList (int _numberOfItems)
	{
		for (int i = 0; i < _numberOfItems; i++) {
            var randItem = (ItemNames)Random.Range(0, System.Enum.GetValues(typeof(ItemNames)).Length) + 1;
            CreateItem(ItemNames.Bark);
        }
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
        if (other.tag == "Player") {
            InventoryDestroy();
        }
    }

	void InventoryDestroy ()
	{
        // iterate through and build a list of the items for processing.
        var heroItems = hhCtrl.heroHolding;   
        
        for (int j = 0; j < heroItems.Count; j++) {

            for (int i = 0; i < requestedItems.Count; i++) {
				if (heroItems[j].itemName == requestedItems[i]) {
                    // correct item
                    RemoveItem(requestedItems[i]);
                    heroItems[j].pointScored = 1;
                }
            }
            DestroyItem(heroItems[j]);
		}
        
        InventoryScoring();
    }

    void DestroyItem (ItemCtrl _go)
    {
        gameCtrl.ScoreChange = _go.pointScored;
        Destroy(_go.gameObject);
    }

    void InventoryScoring()
    {
        if (requestedItems.Count > 0) {
            Debug.Log("You Fool, That's Not Right!");
        }
        else {
            Debug.Log("You Did It");
            CreateRequestItemsList(2);
        }
        hhCtrl.heroHolding.Clear();
    }

}
