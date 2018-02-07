using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public float damage = 10f;
    public float swingCooldown = 1f;

    public float swingLength = 0.5f;
    public Vector3 swingDir;
    public Vector3 swingRot = Vector3.right;
    public Vector3 swingRotPoint = Vector3.zero;
    public float swingAnglePerSec = 1.0f;

    private float swingHeat = 0;
    private float swingTime = 0;
    private bool swinging = false;

    private Vector3 relpos = Vector3.zero;



    private void Start()
    {
        relpos = transform.localPosition; //transform.position - transform.parent.position;
    }

    private void Update()
    {

        swingHeat = Mathf.Clamp(swingHeat - Time.deltaTime, 0f, swingCooldown);

        if(swinging)
        {
            swingTime += Time.deltaTime;

            relpos += transform.TransformDirection(swingDir) * Time.deltaTime;

            Vector3 initpos = transform.position;
            transform.parent.Rotate(swingDir * Time.deltaTime);
            relpos += transform.position - initpos;

            if(swingTime >= swingLength)
            {
                swinging = false;
            }
        }
        else if(!swinging && swingTime > 0)
        {
            swingTime = Mathf.Clamp(swingTime - Time.deltaTime, 0f, swingLength);

            relpos -= transform.TransformDirection(swingDir) * Time.deltaTime;

            Vector3 initpos = transform.position;
            transform.parent.Rotate(swingDir * Time.deltaTime);
            relpos += transform.position - initpos;
        }

        Debug.DrawLine(transform.parent.TransformPoint(relpos), transform.parent.TransformPoint(swingRotPoint));
        transform.position = transform.parent.TransformPoint(relpos);
    }

    public void Swing()
    {
        if(swingHeat == 0 && swingTime == 0)
        {
            swingHeat = swingCooldown;
            swinging = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Battlebot bot = other.GetComponent<Battlebot>();
        if(swinging && bot)
        {
            bot.Damage(damage);
        }
        swinging = false;
    }

}
