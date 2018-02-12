using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public float damage = 10f;
    public float swingCooldown = 1f;

    public float swingLength = 0.5f;
    public Vector3 swingDir;
    public Vector3 swingRot = Vector3.right;
    public float swingAnglePerSec = 1.0f;
    
    private float swingTime = 0;
    private bool swinging = false;
    private Battlebot mybot;

    private Vector3 relpos = Vector3.zero;

    private int starts = 0;
    private int ends = 0;

    private void Start()
    {
        relpos = transform.localPosition; //transform.position - transform.parent.position;
        mybot = transform.parent.GetComponent<Battlebot>();
    }

    private void Update()
    {
        
        if(swinging)
        {
            swingTime += Time.deltaTime;

            transform.position += transform.TransformDirection(swingDir) * Time.deltaTime;
            
            transform.Rotate(swingRot * swingAnglePerSec * Time.deltaTime);

            if(swingTime >= swingLength)
            {
                swinging = false;
            }
        }
        else if(!swinging && swingTime > 0)
        {
            swingTime -= Time.deltaTime;

            transform.position -= transform.TransformDirection(swingDir) * Time.deltaTime;
            
            transform.Rotate(-swingRot * swingAnglePerSec * Time.deltaTime);
        }
        
    }

    public void Swing()
    {
        if(swingTime <= 0)
        {
            swinging = true;
        }
    }

    public void ChildTriggerEnter(Collider other)
    {
        Battlebot bot = other.GetComponent<Battlebot>();
        if (swinging && bot && bot.team != mybot.team)
        {
            bot.Damage(damage);
        }
        swinging = false;
    }

}
