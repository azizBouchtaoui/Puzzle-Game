using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript_ForMediumLevel : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    public void PlayGame(int LevelNumber)
    {
        PlayerPrefs.SetInt("LevelForMediumLevel", LevelNumber);
        SceneManager.LoadScene("GameForMediumLevel");
    }
    public void OpenLink(string URL)
    {
        Application.OpenURL(URL);
    }

    public void QuiteTheGame(){
       
          
          LoadPreviousLevel();
    }

      public void LoadPreviousLevel()
    {

        SceneManager.LoadScene("LevelMenu");

    }
 

    /*
        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(levelIndex);
        }

    */

}
