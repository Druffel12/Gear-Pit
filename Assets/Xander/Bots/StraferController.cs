using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraferController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;

    private Transform target = null;
    private LevelManager manager;

    private float strafeDir = 1f;
    private float strafeTimer;
    private float strafeTimeBase = 3f;
    public float strafeDist = 4f;

    private void Start()
    {
        strafeTimer = strafeTimeBase;
        manager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            // 3-2=1 3-1=2
            target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
        }

        if (target != null && !target.gameObject.activeSelf)
        {
            target = null;
        }

        if (target != null)
        {
            if(Vector3.Distance(transform.position, target.position) > strafeDist)
            {
                Vector3 lookat = target.position;
                //lookat.y = transform.position.y;
                transform.LookAt(lookat);

                bot.MoveTo(target.position);

                bot.Shoot(bullet);
            }
            else
            {
                strafeTimer -= Time.deltaTime;
                if(strafeTimer <= 0)
                {
                    strafeTimer = strafeTimeBase;
                    strafeDir *= -1f;
                }

                Vector3 lookat = target.position;
                //lookat.y = transform.position.y;
                transform.LookAt(lookat);

                Vector3 movePos = transform.position + transform.right * strafeDir;
                movePos += transform.forward;
                bot.MoveTo(movePos);

                bot.Shoot(bullet);
            }
        }
    }

}
