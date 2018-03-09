using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public UnityEngine.UI.Text mpc;
    public UnityEngine.UI.Text AssetsDisplay;
    public float money;
    public float moneyPerClick;
    public bool isFirstLoad = true;


    private void Start()
    {

        if (isFirstLoad == true)
        {
            money = PlayerPrefs.GetFloat("currentMoney", 0);
            moneyPerClick = 1.0f;
        }
        if (isFirstLoad == false && platform2NextLevel.hasWon == true)
        {
            moneyPerClick = PlayerPrefs.GetFloat("currentMoneyPerClick");
            money = PlayerPrefs.GetFloat("currentMoney") + 150000.0f;
        }
        else if (isFirstLoad == false && EnemyMove.hasLost == true)
        {
			moneyPerClick = PlayerPrefs.GetFloat("currentMoneyPerClick");

			money = PlayerPrefs.GetFloat("currentMoney");
        }
        else if (isFirstLoad == false && PlayerScore.hasWon == true)
        {
			moneyPerClick = PlayerPrefs.GetFloat("currentMoneyPerClick");

			money = PlayerPrefs.GetFloat("currentMoney") + 40000.0f;
        }
        //} else if (bulletHellScore.hasWon == true) {
        //money = PlayerPrefs.GetFloat("currentMoney") + 20000.0f;
    


    }

    private void OnApplicationQuit()
    {
        isFirstLoad = true;
    }


    private void Awake()
    {
        moneyPerClick = 1.0f;
        DontDestroyOnLoad(transform.gameObject);

    }

    void Update()
	{
        
        AssetsDisplay.text = "Money: $" + PlayerPrefs.GetFloat("currentMoney");
		mpc.text = PlayerPrefs.GetFloat("currentMoneyPerClick") + " Money/Click";
        SaveCurrentMoney();

	}

	public void Clicked()
	{
        money = PlayerPrefs.GetFloat("currentMoney") + PlayerPrefs.GetFloat("currentMoneyPerClick");
	}

    void SaveCurrentMoney() {
        PlayerPrefs.SetFloat("currentMoney", money);
        PlayerPrefs.SetFloat("currentMoneyPerClick", moneyPerClick);
    }	
}
