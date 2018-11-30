using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position.x > 50.0f || transform.position.x < -50.0f) || (transform.position.y > 50.0f || transform.position.y < -50.0f))
            GetComponent<movement>().PlayerDied();
	}
}
