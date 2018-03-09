using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour {

    public int gameId;
	public Click click;
	public UnityEngine.UI.Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickPower;
	public string itemName;
	private float _baseCost;
    public float sceneDelay = 1.0f;


	void Start()
	{
		_baseCost = cost;
	}

	void Update()
	{
		
		itemInfo.text = itemName + "\nCost: " + cost + "\nPower: +" + clickPower;
	}

	public void PurchasedUpgrade()
	{
        if (click.money >= cost && gameId == 1)
        {

            PlayerPrefs.SetFloat("currentMoneyPerClick", click.moneyPerClick);
            click.money -= cost;
            count += 1;
            click.moneyPerClick += clickPower;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("platformStart");

		} else if (click.money >= cost && gameId == 2)
        {

            PlayerPrefs.SetFloat("currentMoneyPerClick", click.moneyPerClick);
            click.money -= cost;
            count += 1;
            click.moneyPerClick += clickPower;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("BulletHellStart");
        } else if (click.money >= cost && gameId == 3)
        {

            PlayerPrefs.SetFloat("currentMoneyPerClick", click.moneyPerClick);
            click.money -= cost;
            count += 1;
            click.moneyPerClick += clickPower;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("boatStart");
        } else if (click.money >= cost) {
			click.money -= cost;
			count += 1;
			click.moneyPerClick += clickPower;
			cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
        }
        

	}
}
