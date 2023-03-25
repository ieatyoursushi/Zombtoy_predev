using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class CamerPOV : MonoBehaviour {
    bool switching = false;
    public Text projText;

	// Use this for initialization
	void Start () {
		
	}
	public void CameraPerspective()
    {
        if (Input.GetKeyDown(KeyCode.V) && !switching)
        {
            switching = true;
            Camera.main.orthographic = false;
            projText.text = "POV: Perspective (V)";
        }
        else if (Input.GetKeyDown(KeyCode.V) && switching)
        {
            switching = false;
            Camera.main.orthographic = true;
            projText.text = "POV: Orthographic (V)";
        }
    }
 
	// Update is called once per frame
	void Update () {
        CameraPerspective();

    }
}
