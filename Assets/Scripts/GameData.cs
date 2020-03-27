using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<BoardData> boards;

    public GameData(God god)
    {
        boards = god.gameData.boards;
    }

    public GameData()
    {
        boards = new List<BoardData>();
    }

}
