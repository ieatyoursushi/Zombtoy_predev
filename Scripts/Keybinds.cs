using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keybinds : MonoBehaviour
{
    public static string reloadBind = "r";
    public static string slot1Bind = "1";
    public static string slot2Bind = "2";
    public static string slot3Bind = "3";
    public static string slot4Bind = "4";
    public static string slot5Bind = "f";

    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;
    public GameObject InputField4;
    public GameObject InputField5;
    public GameObject InputField6;
    public void storeKey()
    {
        reloadBind = InputField1.GetComponent<Text>().text.ToLower();
        slot1Bind = InputField2.GetComponent<Text>().text.ToLower();
        slot2Bind = InputField3.GetComponent<Text>().text.ToLower();
        slot3Bind = InputField4.GetComponent<Text>().text.ToLower();
        slot4Bind = InputField5.GetComponent<Text>().text.ToLower();
        slot5Bind = InputField6.GetComponent<Text>().text.ToLower();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetButtonUp("Fire1"))
        {
            storeKey();
            Debug.Log(reloadBind + slot1Bind + slot2Bind + slot3Bind + slot4Bind);
            // lol
            if (string.IsNullOrEmpty(reloadBind) || reloadBind == " ")
            {
                reloadBind = InputField1.GetComponent<Text>().text = "r".ToLower();
            }
            if (string.IsNullOrEmpty(slot1Bind) || slot1Bind == " ")
            {
                slot1Bind = InputField2.GetComponent<Text>().text = "1".ToLower();
            }
            if (string.IsNullOrEmpty(slot2Bind) || slot2Bind == " ")
            {
                slot2Bind = InputField3.GetComponent<Text>().text = "2".ToLower();
            }
            if (string.IsNullOrEmpty(slot3Bind) || slot3Bind == " ")
            {
                slot3Bind = InputField4.GetComponent<Text>().text = "3".ToLower();
            }
            if (string.IsNullOrEmpty(slot4Bind) || slot4Bind == " ")
            {
                slot4Bind = InputField5.GetComponent<Text>().text = "4".ToLower();
            }
            if(string.IsNullOrEmpty(slot5Bind) || slot5Bind == " ")
            {
                slot5Bind = InputField6.GetComponent<Text>().text = "f".ToLower();
            }
 
        }
 
    }
}
