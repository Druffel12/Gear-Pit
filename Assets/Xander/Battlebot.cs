using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Battlebot : MonoBehaviour {

    public int team = 1;
    public float maxHealth = 100.0f;
    public float gunCooldown = 0.25f;
    public float bulletDamage = 10.0f;

    private NavMeshAgent agent;
    private Transform bulletSpawn;

    private float health;
    private float gunHeat = 0;

    //might make this public for adjustable bullet speed
    private float bulletForce = 5000.0f;




    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bulletSpawn = transform.Find("BulletSpawn");
        health = maxHealth;

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
        if(health <= 0)
        {
            Kill();
        }
    }

    public float GetHealth()
    {
        return health;
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
            Destroy(b, 10);
        }
    }


    
    private void Kill()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
