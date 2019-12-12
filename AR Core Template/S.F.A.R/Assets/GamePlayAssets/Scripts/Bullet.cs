using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody rb;
    public GameObject SpawnPoint;
    public GameObject Enemy;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Destruction());
    }

    void FixedUpdate()
    {
        if (Enemy != null)
            rb.AddForce((Enemy.transform.position - SpawnPoint.transform.position).normalized * bulletSpeed, ForceMode.Force);            
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            EnemyScript enemyScript = col.GetComponent<EnemyScript>();
            Destroy(gameObject);
            enemyScript.TakeDamage(damage);
        }
    }
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
