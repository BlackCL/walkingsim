using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LimitedRotation : MonoBehaviour
{

    public float cameraSmoothingFactor = 1;
    public float lookUpMax = 20;
    public float lookUpMin = -50;

    //public float lookLeftMax = 60;
    //public float lookRightMax = -60;


    private Quaternion camRotation;


    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;    
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Mouse X") + " : " + Input.GetAxis("Mouse Y"));

        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor*(-1); //look up/down
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor; //look left/right

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax); //clamping max and min look up/down
       // camRotation.y = Mathf.Clamp(camRotation.y, lookLeftMax, lookRightMax); //limiting look left/right

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);

        //Debug.Log(camRotation.x);

        
    }
}
