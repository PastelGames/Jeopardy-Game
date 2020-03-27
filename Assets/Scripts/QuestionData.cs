﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    public string question;
    public string imageLink;
    public bool answered;
    public bool useVisualAid;

    public QuestionData()
    {
        question = "";
        imageLink = "";
        answered = false;
        useVisualAid = false;
    }

}
