using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDrop_ForMediumLevel : MonoBehaviour
{
    public Sprite[] Levels;

    public GameObject EndMenu;
    public GameObject SelectedPiece;
    public GameObject LevelsComplete;
    int OIL = 1;
    public int PlacedPieces = 0;
    public void CompleteLevel()
    {
        LevelsComplete.SetActive(true);
    }

    void Start()
    {

        for (int i = 0; i < 16; i++)
        {
            try
            {


                GameObject.Find("Piece (" + i + ")").transform.Find("PuzzleForMediumLevel").GetComponent<SpriteRenderer>().sprite = Levels[PlayerPrefs.GetInt("LevelForMediumLevel")];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                CompleteLevel();
            }
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("PuzzleForMediumLevel"))
            {
                if (!hit.transform.GetComponent<piceseScriptForMediumLevel>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScriptForMediumLevel>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScriptForMediumLevel>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }             
        if (PlacedPieces == 16)
        {
            EndMenu.SetActive(true);
        }
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelForMediumLevel", PlayerPrefs.GetInt("LevelForMediumLevel") +1);
        SceneManager.LoadScene("GameForMediumLevel");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuForMediumLevel");
    }
    public void BacktoLevels()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}