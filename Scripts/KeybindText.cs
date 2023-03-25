using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeybindText : MonoBehaviour {
    public Text slot1Text;
    public Text slot2Text;
    public Text slot3Text;
    public Text slot4Text;
    public Text reloadText;
    public Text flashlightText;
    // Use this for initialization
    void Start()
    {
        slot1Text.text = Keybinds.slot1Bind;
        slot2Text.text = Keybinds.slot2Bind;
        slot3Text.text = Keybinds.slot3Bind;
        slot4Text.text = Keybinds.slot4Bind;
        reloadText.text = Keybinds.reloadBind;
        flashlightText.text = Keybinds.slot5Bind;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
