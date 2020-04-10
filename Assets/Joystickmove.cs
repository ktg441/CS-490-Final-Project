using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystickmove : MonoBehaviour
{
    public Camera cm;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickstate = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (stickstate[1] != 0)
        {
            rb.AddForce(cm.transform.forward * stickstate[1] * 5f);
        }
        if(stickstate[0] != 0)
        {

            rb.AddForce(cm.transform.right * stickstate[0] * 5f);
        }
    }
}
