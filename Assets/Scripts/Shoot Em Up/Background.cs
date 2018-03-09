using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Transform Background1;
    public Transform Background2;

    private bool whichOne = true;

    public Transform cam;

    private float currentHeight = 20;
	
	// Update is called once per frame
	void Update ()
    {
		if(currentHeight < cam.position.y)
        {
            if (whichOne)
            {
                Background1.localPosition = new Vector3(0, Background1.localPosition.y + 40, 10);
            }
            else
            {
                Background2.localPosition = new Vector3(0, Background2.localPosition.y + 40, 10);
                currentHeight += 20;
                whichOne = !whichOne;   
            }

        }
        
        if(currentHeight < cam.position.y + 20)
        {
            if (whichOne)
            {
                Background2.localPosition = new Vector3(0, Background2.localPosition.y - 40, 10);
            }
            else
            {
                Background1.localPosition = new Vector3(0, Background1.localPosition.y - 40, 10);
                currentHeight -= 20;
                whichOne = !whichOne;
            }
        }
	}
}
