using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public float splodeForce = 1000f;
    public Material mat;

	// Use this for initialization
	void Start ()
    {
        Rigidbody[] parts = GetComponentsInChildren<Rigidbody>();
		foreach(Rigidbody b in parts)
        {
            b.transform.position = transform.position;
            b.transform.localScale = new Vector3(Random.Range(0.1f, 0.5f),
                                                 Random.Range(0.1f, 0.5f),
                                                 Random.Range(0.1f, 0.5f));
            b.AddForce(Random.insideUnitSphere * splodeForce);
            b.AddTorque(Random.insideUnitSphere * splodeForce);
            b.GetComponent<MeshRenderer>().material = mat;
        }
	}
	
}
