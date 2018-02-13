using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicController : MonoBehaviour
{

    public Battlebot bot;
    private Transform ally = null;
    private LevelManager manager;
    private Battlebot Bot;
    public float HealDist;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
        if (ally == null)
        {
            ally = manager.FindClosestBotTo(transform.position, bot.team);
        }

        if (ally != null && ally.gameObject.activeSelf)
        {
            ally = null;
        }

        Vector3 lookat = ally.position;
        transform.LookAt(lookat);

        bot.MoveTo(ally.position);

        if (Vector3.Distance(transform.position, ally.position) < HealDist)
        {
          //  Bot.maxHealth ;
        }



    }
}
