using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProps : MonoBehaviour {

	public string itemName;
	public int itemCode;

	void Awake()
	{
		name = itemName;
	}

}
