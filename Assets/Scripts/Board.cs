using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public List<GameObject> categories;
    public InputField boardNameInputField;
    public Canvas editBoardCanvas;
    public Canvas playBoardCanvas;
    God god;
    Transform board;

    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.Find("God").GetComponent<God>();
        switch(god.currentPlayMode)
        {
            case God.Mode.Edit:

                editBoardCanvas.gameObject.SetActive(true);

                boardNameInputField.text = god.currentBoard.boardName;

                board = editBoardCanvas.transform.Find("Board");

                

                foreach(Transform child in board)
                {
                    child.GetComponentInChildren<Category>().categoryInputField.text = god.currentBoard.categoryData[child.GetSiblingIndex()].categoryName;
                    child.GetComponent<Category>().PopulateQuestions(god.currentBoard.categoryData[child.GetSiblingIndex()]);
                }

                break;

            case God.Mode.Play:
                playBoardCanvas.gameObject.SetActive(true);
                board = playBoardCanvas.transform.Find("Board");
                foreach(Transform child in board)
                {
                    child.GetComponentInChildren<Category>().categoryNameText.text = god.currentBoard.categoryData[child.GetSiblingIndex()].categoryName;
                    child.GetComponent<Category>().PopulateQuestions(god.currentBoard.categoryData[child.GetSiblingIndex()]);
                }
                break;
        }
    }

    public void SaveBoard()
    {
        if (god.currentPlayMode == God.Mode.Edit)
        {
            god.currentBoard.boardName = boardNameInputField.text;
            foreach (Transform child in board)
            {
                god.currentBoard.categoryData[child.GetSiblingIndex()].categoryName = child.GetComponentInChildren<Category>().categoryInputField.text;
            }
        }
        SaveSystem.SaveGame(god);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < board.childCount; i++)
        {
            for(int j = 1; j < board.GetChild(i).childCount; j++)
            {
                if (god.currentPlayMode == God.Mode.Play)
                {
                    if (god.currentBoard.categoryData[i].questions[j - 1].answered)
                    {
                        board.GetChild(i).GetChild(j).gameObject.GetComponentInChildren<Image>().color = Color.red;
                    }
                    else
                    {
                        board.GetChild(i).GetChild(j).gameObject.GetComponentInChildren<Image>().color = Color.white;
                    }
                }
                else
                {
                    if (god.currentBoard.categoryData[i].questions[j - 1].question.Equals("") && god.currentBoard.categoryData[i].questions[j - 1].imageLink.Equals(""))
                    {
                        board.GetChild(i).GetChild(j).gameObject.GetComponentInChildren<Image>().color = Color.white;
                    }
                    else
                    {
                        board.GetChild(i).GetChild(j).gameObject.GetComponentInChildren<Image>().color = Color.green;
                    }
                }
            }
        }
        
    }


}
