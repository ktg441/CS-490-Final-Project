using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadMovement : MonoBehaviour
{
    public Camera cm;
    public Rigidbody rb;
    public GameObject player;

    private Quaternion init_rotation;
    public float acceptable_range = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        init_rotation = cm.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float x_dif = cm.transform.rotation.x - init_rotation.x;
        float z_dif = init_rotation.z - cm.transform.rotation.z;
        if (Mathf.Abs(x_dif) > acceptable_range)
        {
            rb.AddForce(cm.transform.forward * x_dif * 10f);
        }
        if (Mathf.Abs(z_dif) > acceptable_range)
        {
            rb.AddForce(cm.transform.right * z_dif * 10f);
        }
        if (this.transform.position.y < -10)
        {
            GameObject.Find("Stats Canvas").GetComponent<Stats>().AddDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Vector3 self3 = transform.position;
        //self3.y = player.transform.position.y;
        player.transform.position = self3;
    }
}
