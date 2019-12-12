using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCoreInternal;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class PlayerInput : MonoBehaviour
{

    public GoogleARCore.ARCoreSession ar;
    public Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        ar = GameObject.FindGameObjectWithTag("ArCoreDevice").GetComponent<GoogleARCore.ARCoreSession>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ar.disablePlaneDetection();
            }
        }
      

        
    }
}
