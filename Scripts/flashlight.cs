using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class flashlight : MonoBehaviour {
    public bool flash = false;
    public Text text;
    PlayerHealth playerHealth;
    // Use this for initialization
    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    void Start () {
        gameObject.GetComponent<Light>().enabled = false;
        text.text = "Flashlight: Disabled " + "(" + Keybinds.slot5Bind + ")";
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(Keybinds.slot5Bind) && !playerHealth.isDead)
        {
            GetComponent<AudioSource>().Play();
            flash = !flash;
            if(flash)
            {
                gameObject.GetComponent<Light>().enabled = true;
                text.text = "Flashlight: Enabled " + "(" + Keybinds.slot5Bind + ")";
            } else
            {
                gameObject.GetComponent<Light>().enabled = false;
                text.text = "Flashlight: Disabled " + "(" + Keybinds.slot5Bind + ")";
            }
        }  
	}
}
