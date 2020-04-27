using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joystickmove : MonoBehaviour
{
    public Camera cm;
    public Rigidbody rb;
    public GameObject player;
    float oldx = 0;
    float oldy = 0;
    float oldz = 0;
    int xflip = 0;
    int yflip = 0;
    int zflip = 0;
    int flip = 0;
    int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Vector3 self3 = transform.position;
        //self3.y = player.transform.position.y;
        player.transform.position = self3;
        timer++;
        if (OVRInput.Get(OVRInput.Button.One) && (timer > 20))
        {
            timer = 0;
            if (flip == 0) {
                flip = 1;
            }
            else if (flip == 1) {
                flip = 0;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        if (flip == 1)
        {

            //float xdif = transform.rotation.x - oldx;
            //float ydif = transform.rotation.y - oldy;
            //float zdif = transform.rotation.z - oldz;

            //oldx = transform.rotation.x;
            //oldy = transform.rotation.y;
            //oldz = transform.rotation.z;

            //Quaternion nuvers = player.transform.rotation;
            //nuvers.x = xdif + player.transform.rotation.x;
            //nuvers.y = ydif + player.transform.rotation.y;
            //nuvers.z = zdif + player.transform.rotation.z;
            player.transform.rotation = transform.rotation;
        }
        else
        {
            Vector2 stickstate = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            if (stickstate[1] != 0)
            {
                rb.AddForce(cm.transform.forward * stickstate[1] * 3f);
            }
            if (stickstate[0] != 0)
            {
                rb.AddForce(cm.transform.right * stickstate[0] * 3f);
            }
            if (this.transform.position.y < -10)
            {
                GameObject.Find("Stats Canvas").GetComponent<Stats>().AddDeath();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        }
}
