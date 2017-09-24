using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCtrl : MonoBehaviour {

	public Text itemsList;
    public Text messagehDisplay;
    string updatedItemsList;

	public void UpdateRequestList ()
	{		
		updatedItemsList = "";
		
		foreach (string item in GameObject.Find("Home Base").GetComponent<HomeBaseCtrl>().requestedItems) {
			updatedItemsList += item + "\n";
		}

		itemsList.text = updatedItemsList;
	}
}
