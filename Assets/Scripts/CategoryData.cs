using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CategoryData
{
    public string categoryName;
    public QuestionData[] questions;

    public CategoryData()
    {
        questions = new QuestionData[5];
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i] = new QuestionData();
        }
    }
}
