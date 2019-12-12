using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int life = 10;
    public float speed = 5f;
    public int recompense;
    public GameObject Base;
    Rigidbody rb;
    EconomyScript economyScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        economyScript = GameObject.Find("EcoManager").GetComponent<EconomyScript>();
    }
    void FixedUpdate()
    {
       
           rb.AddForce((Base.transform.position - transform.position).normalized * speed, ForceMode.Force);       
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Death();
    }
    void Death()
    {
        Destroy(gameObject);
        economyScript.RentreArgent(recompense);
    }

}

