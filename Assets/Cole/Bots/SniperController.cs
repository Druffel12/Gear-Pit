using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperController : MonoBehaviour
{
    private Transform enemy = null;
    public GameObject Bullet;
    public Battlebot bot;
    private LevelManager manager;
    private float SnipeDist = 20;
    public GameObject OtherBot;

    // Use this for initialization
    private void Start ()
    {
        manager = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (enemy == null && manager != null)
        {
            enemy = manager.FindClosestBotTo(transform.position, 3 - bot.team); 
        }

        if (enemy != null && !enemy.gameObject.activeSelf)
        {
            enemy = null;
        }

        else if(enemy == null)
        {
            enemy = OtherBot.transform;    
        }

        if(enemy != null)
        {
            //bot.Shoot(Bullet);
            Vector3 moveDir = (transform.position - enemy.position).normalized;
            Vector3 lookat = enemy.position;
            transform.LookAt(lookat);
            if (Vector3.Distance(transform.position, enemy.position) < SnipeDist)
            {

                
                bot.MoveTo(transform.position + moveDir);
            }

            else if (Vector3.Distance(transform.position, enemy.position) > SnipeDist + 7) 
            {
                bot.MoveTo(enemy.position);
            }
            // Debug.DrawLine(transform.position, transform.position + (moveDir * 10));
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                
                    Battlebot trgbot = hit.transform.GetComponent<Battlebot>();

                    if (trgbot != null && trgbot.team != bot.team)
                    {
                    //SnipeDist = 20;
                        bot.Shoot(Bullet);
                    }
                    else
                {
                    bot.MoveTo(enemy.position);
                    //MOVE REALLY CLOSE TO THE GUY UNTIL THIS ELSE STOPS HAPPENING
                }
                
               
            }
        }
    }
}
