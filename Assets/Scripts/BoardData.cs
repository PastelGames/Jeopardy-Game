using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoardData
{
    public string boardName;
    public CategoryData[] categoryData;

    public BoardData()
    {
        boardName = "";
        categoryData = new CategoryData[5];
        for(int i = 0; i < categoryData.Length; i++)
        {
            categoryData[i] = new CategoryData();
        }
    }
}
