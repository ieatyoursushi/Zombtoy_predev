using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour {
    public bool inRange;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider Range)
    {
        if(Range.gameObject.name == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider Range)
    {
        if (Range.gameObject.name == "Player")
        {
            inRange = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
