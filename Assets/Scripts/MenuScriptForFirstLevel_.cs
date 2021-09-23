using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScriptForFirstLevel_ : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    public void PlayGame(int LevelNumber)
    {
        PlayerPrefs.SetInt("LevelForFirstLevel", LevelNumber);
        SceneManager.LoadScene("firstLevel");
    }
    public void OpenLink(string URL)
    {
        Application.OpenURL(URL);
    }

    public void QuiteTheGame()
    {
        LoadPreviousLevel();
    }

    public void LoadPreviousLevel()
    {
        //int sceneName = PlayerPrefs.GetInt("lastLoadedScene");
        // StartCoroutine(LoadLevel(sceneName));

        SceneManager.LoadScene("LevelMenu");
    }
IEnumerator LoadLevel(string LevelMenu)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelMenu);
    }

   /* IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }


    */
}
