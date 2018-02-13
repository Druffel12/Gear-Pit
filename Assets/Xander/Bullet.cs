using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10;
    public GameObject mySound;

    private void OnCollisionEnter(Collision collision)
    {
        Battlebot bot = collision.gameObject.GetComponent<Battlebot>();
        if (bot != null)
        {
            bot.Damage(damage);

            if(mySound)
            {
                mySound.SetActive(true);
                mySound.transform.parent = null;
                mySound.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 2.0f);
                Destroy(mySound, 2);
            }
        }

        Destroy(gameObject);
    }

}
