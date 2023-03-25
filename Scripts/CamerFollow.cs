using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {
    public Transform target; // target for camera to follow
    public float smoothing = 5f; // want a little bit of lag to follow the player

    Vector3 offset; //store the camrea offset
	void Start () {
        offset = transform.position - target.position;
	}
	
	
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        
	}
}
