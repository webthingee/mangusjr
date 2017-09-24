using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttr : MonoBehaviour {

	[SerializeField] string charName;
	public string CharName {
		get { return this.charName; }
		set { this.charName = value; }
	}

    [SerializeField] int charHealth;
    public int CharHealth {
        get { return this.charHealth; }
    }
    public int CharHealthChange {
        set { charHealth += value; }
    }

    public void RemoveharHealth (int _value)
    {
        this.charHealth -= _value;
        if (this.tag != "Player" && this.charHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        if ((this.tag == "Player" || this.tag == "Home") && this.charHealth <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameCtrl>().EndGame();
        }
    }
}
