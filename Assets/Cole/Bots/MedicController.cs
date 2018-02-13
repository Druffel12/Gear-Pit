using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicController : MonoBehaviour
{

    public Battlebot bot;
    private Transform ally = null;
    private LevelManager manager;

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
        	
	}
}
