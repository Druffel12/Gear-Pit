using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBotController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;
    
	// Update is called once per frame
	void Update () {
        bot.Shoot(bullet);
        Vector3 s = Random.onUnitSphere;
        s.y = transform.position.y;
        bot.LookAt(s);
        bot.MoveTo(transform.position + transform.forward);
	}

}
