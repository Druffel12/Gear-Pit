using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Battlebot : MonoBehaviour {

    public int team = 1;
    public float maxHealth = 100.0f;
    public float gunCooldown = 0.25f;
    public float bulletDamage = 10.0f;

    public GameObject explosion = null;
    
    public AudioClip[] gunSounds;

    private NavMeshAgent agent;
    private Transform bulletSpawn;
    private RectTransform healthBar;
    private GameObject teamIcon;
    private MeleeWeapon weapon;
    private GameObject mySplode;
    private AudioSource shootAudio;

    private float health;
    private float gunHeat = 0;

    //might make this public for adjustable bullet speed
    private float bulletForce = 3000.0f;




    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bulletSpawn = transform.Find("BulletSpawn");
        healthBar = transform.Find("Canvas").Find("HealthBackground").Find("Health").GetComponent<RectTransform>();
        teamIcon = transform.Find("Canvas").Find("TeamIcons").gameObject;
        weapon = GetComponentInChildren<MeleeWeapon>();
        shootAudio = GetComponent<AudioSource>();
        health = maxHealth;

        mySplode = Instantiate(explosion);
        mySplode.GetComponent<Explode>().mat = GetComponent<MeshRenderer>().material;

        if (team == 1)
        {
            teamIcon.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            teamIcon.GetComponent<Image>().color = Color.red;
        }

        agent.enabled = true;
    }

    private void Update()
    {
        gunHeat = Mathf.Clamp(gunHeat - Time.deltaTime, 0, gunCooldown);
    }



    public void Damage(float amt)
    {
        health -= amt;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.localScale = new Vector3(health / maxHealth, 1f, 1f);
        if(health <= 0)
        {
            Kill();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }

    public void MoveTo(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }

    public void Shoot(GameObject bulletPrefab)
    {
        if(gunHeat == 0)
        {
            gunHeat = gunCooldown;
            GameObject b = Instantiate(bulletPrefab);
            b.transform.position = bulletSpawn.position;
            b.transform.rotation = bulletSpawn.rotation;
            Bullet bscript = b.GetComponent<Bullet>();
            bscript.damage = bulletDamage;
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * bulletForce);
            //will make longer eventually, here in case bullet escapes map
            if(gunSounds.Length > 0)
            {
                shootAudio.clip = gunSounds[Random.Range(0, gunSounds.Length)];
                shootAudio.Play();
            }
            Destroy(b, 10);
        }
    }

    public void Swing()
    {
        if(weapon != null)
        {
            weapon.Swing();
        }
    }


    
    private void Kill()
    {
        //Destroy(gameObject);
        if(explosion)
        {
            //GameObject e = Instantiate(explosion);
            mySplode.transform.position = transform.position;
            mySplode.SetActive(true);
            //Destroy(e, 2);
        }
        gameObject.SetActive(false);
    }

}
