using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Battlebot bot = collision.gameObject.GetComponent<Battlebot>();
        if (bot != null)
        {
            bot.Damage(damage);
        }

        Destroy(gameObject);
    }

}
