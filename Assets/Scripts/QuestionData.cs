using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    string question;
    string imageLink;

    public QuestionData()
    {
        question = "";
        imageLink = "";
    }

    public QuestionData(string question, string imageLink)
    {
        this.question = question;
        this.imageLink = imageLink;
    }
}
