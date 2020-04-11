using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadStick()
    {
        Debug.Log("Stick clicked");
        SceneManager.LoadScene("Controller_Level_1");
    }

    public void LoadHead()
    {
        SceneManager.LoadScene("Head_Tilt_Level_1");
    }
}
