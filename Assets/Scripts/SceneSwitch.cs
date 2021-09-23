using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static string prevScene;
    public static string currentScene;
    public static int x;

    

    // Start is called before the first frame update

    public virtual void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;


       

    }

    public void   SwitchScene(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);
    }

}
