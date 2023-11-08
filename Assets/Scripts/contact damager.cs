using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactdamager : MonoBehaviour
{
    public float damage;
    
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Life life = other.GetComponent<Life>();
        if(life != null)
        {
            life.amount -= damage;
        }
    }
}