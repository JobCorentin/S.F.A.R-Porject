using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefense : MonoBehaviour
{
    public GameObject bullet;
    public GameObject SpawnPoint;
    public float attackCoolDown = 1f;
    bool attack;
    float currentTime;
    private GameObject EnemyInst;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            Attack();

            if (EnemyInst == null)
            {
                attack = false;
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            EnemyInst = col.gameObject;

                attack = true;

        }
 
    }
    void Attack()
    {         
        currentTime += Time.deltaTime;
        if (currentTime > attackCoolDown)
        {
            GameObject _bullet = Instantiate(bullet, SpawnPoint.transform);
            _bullet.GetComponent<Bullet>().SpawnPoint = SpawnPoint;
            _bullet.GetComponent<Bullet>().Enemy = EnemyInst;
            currentTime = 0f;
        }
    }


}
