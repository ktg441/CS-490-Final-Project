using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joystickmove : MonoBehaviour
{
    public Camera cm;
    public Rigidbody rb;
    public GameObject player;
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
            rb.AddForce(cm.transform.forward * stickstate[1] * 3f);
        }
        if(stickstate[0] != 0)
        {
            rb.AddForce(cm.transform.right * stickstate[0] * 3f);
        }
        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Vector3 self3 = transform.position;
        self3.z = player.transform.position.z;
        player.transform.position = self3;
    }
}
