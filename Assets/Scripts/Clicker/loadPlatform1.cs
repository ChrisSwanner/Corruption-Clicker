using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadPlatform1 : MonoBehaviour
{
	public void LoadScene()
	{
		PlayerPrefs.GetFloat("currentMoney");

		SceneManager.LoadScene("Platform1");
	}
}