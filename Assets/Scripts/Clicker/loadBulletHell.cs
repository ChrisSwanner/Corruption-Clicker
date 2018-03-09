using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadBulletHell : MonoBehaviour {

	public void LoadScene()
	{
		PlayerPrefs.GetFloat("currentMoney");

		SceneManager.LoadScene("BulletHell");
	}
}
