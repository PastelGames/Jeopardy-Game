using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{

    public enum Mode { Play, Edit };
    public Mode currentPlayMode;
    public GameData gameData;
    public BoardData currentBoard;
    public QuestionData currentQuestion;
    SceneSwapper ss;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameData = SaveSystem.LoadGame();
        ss = GameObject.Find("SceneSwapper").GetComponent<SceneSwapper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteBoard()
    {
        Debug.Log(gameData.boards.Remove(currentBoard));
    }

    public void SetModePlay()
    {
        currentPlayMode = Mode.Play;
    }

    public void SetModeEdit()
    {
        currentPlayMode = Mode.Edit;
    }

    public void SetCurrentBoard(int index)
    {
        currentBoard = gameData.boards[index];
    }

    public void SetCurrentQuestion(QuestionData data)
    {
        currentQuestion = data;
    }

    public void ResetBoard(BoardData board)
    {
        foreach(CategoryData category in board.categoryData)
        {
            foreach(QuestionData question in category.questions)
            {
                question.answered = false;
            }
        }
    }
}


