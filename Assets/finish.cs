using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(ball.transform.position.z - transform.position.z) + Mathf.Abs(ball.transform.position.y - transform.position.y) + Mathf.Abs(ball.transform.position.x - transform.position.x)) < 2)
        {
            print("victory!");//change scene
            switch (SceneManager.GetActiveScene().name)
            {
                case "Controller_Level_1":
                    SceneManager.LoadScene("Controller_Level_2");
                    break;
                case "Controller_Level_2":
                    SceneManager.LoadScene("Controller_Level_3");
                    break;
            }
        }
    }
}
