using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitter : MonoBehaviour {
    
    private MeleeWeapon weapon;

    private void Start()
    {
        weapon = transform.parent.GetComponent<MeleeWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(weapon)
        {
            weapon.ChildTriggerEnter(other);
        }
    }

}
