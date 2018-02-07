using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTestController : MonoBehaviour
{
    private Transform target = null;
    public GameObject Bullet;
    public Battlebot BotTest;
  //  public BotController Controller;

    // Use this for initialization
    void Start ()
    {

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        BotTest.Shoot(Bullet);
        Vector3 lookat = target.position;
        BotTest.MoveTo(transform.position + target.position);


        if (target == null)
        {
         //   target =Controller.FindClosestBotTo(transform.position, 3 - bot.team);
        }
    }
}
