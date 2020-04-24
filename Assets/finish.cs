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
                case "Controller_Level_3":
                    SceneManager.LoadScene("Controller_Level_4");
                    break;
                case "Controller_Level_4":
                    SceneManager.LoadScene("Controller_Level_5");
                    break;
                case "Controller_Level_5":
                    SceneManager.LoadScene("Controller_Level_6");
                    break;
                case "Controller_Level_6":
                    SceneManager.LoadScene("Controller_Level_7");
                    break;
                case "Controller_Level_7":
                    //Kick Back to load screen
                    break;
                case "Head_Tilt_Level_1":
                    SceneManager.LoadScene("Head_Tilt_Level_2");
                    break;
                case "Head_Tilt_Level_2":
                    SceneManager.LoadScene("Head_Tilt_Level_3");
                    break;
                case "Head_Tilt_Level_3":
                    SceneManager.LoadScene("Head_Tilt_Level_4");
                    break;
                case "Head_Tilt_Level_4":
                    SceneManager.LoadScene("Head_Tilt_Level_5");
                    break;
                case "Head_Tilt_Level_5":
                    SceneManager.LoadScene("Head_Tilt_Level_6");
                    break;
                case "Head_Tilt_Level_6":
                    SceneManager.LoadScene("Head_Tilt_Level_7");
                    break;
                case "Head_Tilt_Level_7":
                    //Kick back to load screen
                    break;
            }
        }
    }
}
