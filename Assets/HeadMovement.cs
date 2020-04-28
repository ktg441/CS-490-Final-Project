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
        if (this.transform.position.y < -10)
        {
            GameObject.Find("Stats Canvas").GetComponent<Stats>().AddDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Vector3 self3 = transform.position;
        //self3.y = player.transform.position.y;
        player.transform.position = self3;
        Debug.Log(cm.transform.rotation.z);

        if (cm.transform.forward.y < -acceptable_range)
        {
            rb.AddForce(cm.transform.forward * 3f);
        }
        else if (cm.transform.forward.y > acceptable_range)
        {
            rb.AddForce(cm.transform.forward * -3f);
        }

        if (Mathf.Abs(cm.transform.rotation.z) > acceptable_range)
        {
            rb.AddForce(cm.transform.right * cm.transform.rotation.z * -10f);
        }

    }
}
