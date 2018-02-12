using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraferController : MonoBehaviour {

    public Battlebot bot;
    public GameObject bullet;

    public Transform target = null;
    private bool targIsMelee = false;

    public float baseStrafeDist = 4f;
    public float baseFleeDist = 2f;
    public float meleeDistMod = 5f;
    public bool useHivemind = false;
    private float strafeDist = 0;
    private float fleeDist = 0;

    private LevelManager manager;

    private float strafeDir = 1f;
    private float reTargTimer;
    private float reTargTimerBase = 1f;

    private void Start()
    {
        baseStrafeDist += Random.Range(-2.0f, 2.0f);

        int roll = Random.Range(0, 2);
        if(roll == 0)
        {
            strafeDir = -1f;
        }
        
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
            targIsMelee = StraferHivemind.targetIsMelee;
            SetDistances();
        }

        if (target == null)
        {
            FindTarget();
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
                FindTarget();
                reTargTimer = reTargTimerBase;
            }

            if (Vector3.Distance(transform.position, target.position) > strafeDist)
            {
                Vector3 lookat = target.position;
                transform.LookAt(lookat);

                bot.MoveTo(target.position);
            }
            else if (Vector3.Distance(transform.position, target.position) < fleeDist)
            {
                Vector3 lookat = target.position;
                transform.LookAt(lookat);

                Vector3 moveVec = transform.position -transform.forward;
                bot.MoveTo(moveVec);
            }
            else
            {

                Vector3 lookat = target.position;
                transform.LookAt(lookat);

                Vector3 movePos = transform.position + transform.right * strafeDir;
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

    private void FindTarget()
    {
        // 3-2=1 3-1=2
        target = manager.FindClosestBotTo(transform.position, 3 - bot.team);
        if (target && target.GetComponentInChildren<MeleeWeapon>())
        {
            targIsMelee = true;
        }
        SetDistances();
    }

    private void SetDistances()
    {
        if(targIsMelee)
        {
            strafeDist = baseStrafeDist + meleeDistMod;
            fleeDist = baseFleeDist + meleeDistMod;
        }
        else
        {
            strafeDist = baseStrafeDist;
            fleeDist = baseFleeDist;
        }
    }

}

public static class StraferHivemind
{
    public static Transform target = null;
    public static bool targetIsMelee = false;
}
