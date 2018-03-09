using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlatformer : MonoBehaviour {
    public Click click;
	public void LoadScene()
	{
	
		SceneManager.LoadScene ("Platform1");

	}
}
