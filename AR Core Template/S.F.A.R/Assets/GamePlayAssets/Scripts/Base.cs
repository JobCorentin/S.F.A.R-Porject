using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int life = 20;

    void OnTriggerEnter(Collider col)
    {
       if(col.tag == "Enemy")
        {
            life -= 1;
            if (life <= 0)
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        Destroy(gameObject);
    }
}
