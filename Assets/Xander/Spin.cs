using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public Vector3 anglesPerSec = Vector3.zero;

	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(anglesPerSec * Time.deltaTime);	
	}
}
