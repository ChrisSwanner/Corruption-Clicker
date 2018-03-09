using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public UnityEngine.UI.Text itemInfo;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	private float _basecost;

	void Start()
	{
		_basecost = cost;
	}

	void Update()
	{
		itemInfo.text = itemName + "\nCost: " + cost + "\nMoney: " + tickValue + "/s";
	}

	public void PurchasedItem()
	{
		if (click.money >= cost) 
		{
			click.money -= cost;
			count += 1;
			cost = Mathf.Round (_basecost * Mathf.Pow (1.25f, count));
		}
	}
}
