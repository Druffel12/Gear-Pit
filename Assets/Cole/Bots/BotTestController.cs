using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTestController : MonoBehaviour
{
    private Transform enemy = null;
    public GameObject Bullet;
    public Battlebot BotTest;
    public Battlebot bot;
    private LevelManager manager;

    // Use this for initialization
    private void Start ()
    {
        manager = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (enemy == null)
        {
            enemy = manager.FindClosestBotTo(transform.position, 3 - bot.team); 
        }

        if(enemy != null)
        {
            BotTest.Shoot(Bullet);
            Vector3 lookat = enemy.position;
            transform.LookAt(lookat);
            BotTest.MoveTo(transform.position + enemy.position);
        }
    }
}
