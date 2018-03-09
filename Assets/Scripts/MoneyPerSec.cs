using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPerSec : MonoBehaviour {

	public UnityEngine.UI.Text mpsDisplay;
	public Click click;
	public ItemManager[] items;

	void Start()
	{
		StartCoroutine (AutoTick ());
	}

	void Update()
	{
		mpsDisplay.text = GetMPS () + " money/sec";
	}

	public int GetMPS()
	{
		int tick = 0;
		foreach (ItemManager item in items) 
		{
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoMPS()
	{
		click.money += GetMPS ();
	}

	IEnumerator AutoTick()
	{
		while (true) 
		{
			AutoMPS ();
			yield return new WaitForSeconds(1);
		}
	}
}
