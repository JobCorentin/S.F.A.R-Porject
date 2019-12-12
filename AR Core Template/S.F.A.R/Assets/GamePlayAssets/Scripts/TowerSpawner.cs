using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject Tower;
    public Renderer rend;
    public EconomyScript economyScript;
    bool canPutTower;
    bool enoughMoney;
    public int cout;

    void Start()
    {
        economyScript = GameObject.Find("EcoManager").GetComponent<EconomyScript>();
        canPutTower = true;
    }
    void Update()
    {
        if (cout > economyScript.money)
            enoughMoney = false;
        else
            enoughMoney = true;
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }
    void OnMouseExit()
    {
        rend.material.color = Color.magenta;
    }
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canPutTower && enoughMoney)
        {
            Instantiate(Tower, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            economyScript.DepenseArgent(cout);
            canPutTower = false;
        }
    }
}
