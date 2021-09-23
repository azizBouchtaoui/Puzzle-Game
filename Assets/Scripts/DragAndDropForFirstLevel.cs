using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDropForFirstLevel : MonoBehaviour
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

        for (int i = 0; i < 4; i++)
        {
            try
            {

             
            GameObject.Find("Piece (" + i + ")").transform.Find("PuzzleForFirstLevel").GetComponent<SpriteRenderer>().sprite = Levels[PlayerPrefs.GetInt("LevelForFirstLevel")];
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
            if (hit.transform.CompareTag("PuzzleForFirstLevel"))
            {
                if (!hit.transform.GetComponent<PieceseScriptForFirstLevel>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PieceseScriptForFirstLevel>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PieceseScriptForFirstLevel>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
        if (PlacedPieces == 4)
        {
            EndMenu.SetActive(true);
        }
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelForFirstLevel", PlayerPrefs.GetInt("LevelForFirstLevel") + 1);
        SceneManager.LoadScene("firstLevel");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void BacktoLevels()
    {
        SceneManager.LoadScene("MenuForFirstLevel");
    }
}