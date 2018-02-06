using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;

    private Transform target = null;
    private LevelManager manager;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Vector3 lookat = target.position;
            //lookat.y = transform.position.y;
            transform.LookAt(lookat);

            bot.MoveTo(target.position);

            bot.Shoot(bullet);
        }
    }

}
