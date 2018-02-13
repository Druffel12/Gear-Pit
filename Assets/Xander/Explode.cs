using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public float splodeForce = 1000f;
    public AudioClip[] sounds;
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

        if(sounds.Length > 0)
        {
            AudioSource src = GetComponent<AudioSource>();
            src.clip = sounds[Random.Range(0, sounds.Length)];
            src.Play();
        }

        Invoke("Deactivate", 2);
	}

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
	
}
