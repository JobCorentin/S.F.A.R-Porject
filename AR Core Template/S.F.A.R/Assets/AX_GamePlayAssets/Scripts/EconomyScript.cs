using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyScript : MonoBehaviour
{
    TMPro.TextMeshPro Money;
    public int money;
    private Transform camera;
    void Start()
    {
        Money = GetComponent<TMPro.TextMeshPro>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        Money.text = money.ToString() ;
        transform.LookAt(camera);
    }

    public void RentreArgent(int somme)
    {
        money += somme;
    }
    public void DepenseArgent(int somme)
    {
        money -= somme;
    }
}
