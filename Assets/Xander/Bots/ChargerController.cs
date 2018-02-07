using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;

    public bool useHivemind = false;

    private Transform target = null; 
    private LevelManager manager;

    private float reTargTimer;
    private float reTargTimerBase = 1f;



    private void Start()
    {
        manager = GameObject.FindObjectOfType<LevelManager>();

        reTargTimerBase += Random.Range(-0.25f, 0.5f);
        reTargTimer = reTargTimerBase;
    }

    // Update is called once per frame
    void Update()
    {
        if(useHivemind)
        {
            target = ChargerHivemind.target;
        }

        if(target == null)
        {
            // 3-2=1 3-1=2
            target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
        }

        if(target != null && !target.gameObject.activeSelf)
        {
            target = null;
        }

        if (target != null)
        {
            reTargTimer -= Time.deltaTime;
            if (reTargTimer <= 0)
            {
                target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
                reTargTimer = reTargTimerBase;
            }

            Vector3 lookat = target.position;
            //lookat.y = transform.position.y;
            transform.LookAt(lookat);

            bot.MoveTo(target.position);

            //RaycastHit hit;
            //if(Physics.Raycast(transform.position, transform.forward, out hit))
            //{
            //    Battlebot trgbot = hit.transform.GetComponent<Battlebot>();
            //    if(trgbot != null && trgbot.team != bot.team)
            //    {
            //        bot.Shoot(bullet);
            //    }
            //}

            //bot.Shoot(bullet);
        }

        bot.Swing();

        if(useHivemind)
        {
            ChargerHivemind.target = target;
        }
    }

}

public static class ChargerHivemind
{
    public static Transform target = null;
}
