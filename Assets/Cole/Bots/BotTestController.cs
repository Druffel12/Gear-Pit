using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTestController : MonoBehaviour {

    public GameObject Bullet;
    public Battlebot BotTest;

    // Use this for initialization
    void Start ()
    {

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        BotTest.Shoot(Bullet);
        BotTest.MoveTo(transform.position + transform.forward);
	}
}
