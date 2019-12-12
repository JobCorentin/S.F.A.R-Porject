using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{

    Camera camera;
    Transform Me;
    public Transform child;
    public GameObject laTourDeSauron;
    public GameObject enemy;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        Me = this.transform;
        camera = this.GetComponent<Camera>();
        playerInput = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInput>();
        playerInput.touch.phase = TouchPhase.Canceled;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (Me.position, child.position - Me.position);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("Object");
        //if (Input.touchCount > 0)  
        //{

            if (playerInput.touch.phase == TouchPhase.Began && Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask))
            {
                print(hit.transform.name + "traverse le rayon");
                laTourDeSauron.transform.position = hit.point;
                enemy.transform.position = hit.point;
            }
            
        //}

    }
}
