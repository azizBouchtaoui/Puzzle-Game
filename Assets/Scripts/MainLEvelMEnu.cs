using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainLEvelMEnu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    [SerializeField]
    private string sceneName;

    SceneSwitch sceneSwitch;

    void Start()
    {
        

        sceneSwitch = FindObjectOfType<SceneSwitch>();
        //148.9669  6.194751    53.56

    }


    public void LevelEasy()
    {
        SceneManager.LoadScene("MenuForFirstLevel");
    }
    public void LevelMedium()
    {
        SceneManager.LoadScene("MenuForMediumLevel");
    }
    public void LevelHard()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuiteTheGame()
    {
     
        Application.Quit();
    }

   
}
