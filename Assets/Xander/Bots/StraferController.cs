using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraferController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;

    public Transform target = null;

    public float strafeDist = 4f;
    public float fleeDist = 2f;
    public bool useHivemind = false;

    private LevelManager manager;

    private float strafeDir = 1f;
    private float strafeTimer;
    private float strafeTimeBase = 3f;
    private float reTargTimer;
    private float reTargTimerBase = 1f;

    private void Start()
    {
        strafeDist += Random.Range(-2.0f, 2.0f);
        strafeTimeBase += Random.Range(-1.0f, 5.0f);

        strafeTimer = strafeTimeBase;
        manager = GameObject.FindObjectOfType<LevelManager>();

        reTargTimerBase += Random.Range(-0.25f, 0.5f);
        reTargTimer = reTargTimerBase;
    }

    // Update is called once per frame
    void Update()
    {
        if (useHivemind)
        {
            target = StraferHivemind.target;
        }

        if (target == null)
        {
            // 3-2=1 3-1=2
            target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
        }

        if (target != null && !target.gameObject.activeInHierarchy)
        {
            target = null;
        }

        if (target != null)
        {
            reTargTimer -= Time.deltaTime;
            if(reTargTimer <= 0)
            {
                target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
                reTargTimer = reTargTimerBase;
            }

            if (Vector3.Distance(transform.position, target.position) > strafeDist)
            {
                Vector3 lookat = target.position;
                //lookat.y = transform.position.y;
                transform.LookAt(lookat);

                bot.MoveTo(target.position);
            }
            else if (Vector3.Distance(transform.position, target.position) < fleeDist)
            {
                Vector3 lookat = target.position;
                //lookat.y = transform.position.y;
                transform.LookAt(lookat);

                Vector3 moveVec = transform.position -transform.forward;
                bot.MoveTo(moveVec);
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
                //movePos += transform.forward;
                bot.MoveTo(movePos);
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Battlebot trgbot = hit.transform.GetComponent<Battlebot>();
                if (trgbot != null && trgbot.team != bot.team)
                {
                    bot.Shoot(bullet);
                }
            }
        }

        if (useHivemind)
        {
            StraferHivemind.target = target;
        }
    }

}

public static class StraferHivemind
{
    public static Transform target = null;
}
