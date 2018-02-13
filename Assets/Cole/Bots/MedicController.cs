using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicController : MonoBehaviour
{

    public Battlebot bot;
    public Transform ally = null;
    private LevelManager manager;
    public Battlebot allyBot;
    public float HealDist;

	// Use this for initialization
	void Start ()
    {
        bot = GetComponent<Battlebot>();
        manager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

         if (ally == null)
         {
             ally = manager.FindClosestBotTo(transform.position, bot.team);
             allyBot = ally.GetComponent<Battlebot>(); 
         }

        /*   if (ally != null && ally.gameObject.activeSelf)
           {
               ally = null;
           }*/

        Vector3 lookat = ally.position;
        transform.LookAt(lookat);

        bot.MoveTo(ally.position);

        if (Vector3.Distance(transform.position, ally.position) < HealDist)
        {
            allyBot.Damage(- 10);
            if (allyBot.GetHealth() == allyBot.maxHealth)
            {
                ally = null;
            }
            
            
        }



    }
}
