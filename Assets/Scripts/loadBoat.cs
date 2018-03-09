using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadBoat : MonoBehaviour
{
	public float money;
    public Click click;


    public void CostMoney () {
        click.money -= 5000.0f;
    }
	public void LoadScene()
    {
		SceneManager.LoadScene("ShootEmUp");
	}
}
