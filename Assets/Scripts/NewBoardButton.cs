using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBoardButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        God god = GameObject.Find("God").GetComponent<God>();
        GetComponent<Button>().onClick.AddListener(delegate
        {
            BoardData newBoard = new BoardData();
            newBoard.boardName = "Untitled " + (god.gameData.boards.Count + 1);
            god.gameData.boards.Add(newBoard);
            god.currentBoard = newBoard;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
