using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public Text questionTextBox;
    public Text answerTextBox;
    public Image playVisualAid;
    public Image editVisualAid;
    public Toggle revealAnswer;
    public string imageURL;
    public InputField questionInputField;
    public InputField imageURLInputField;
    public InputField answerInputField;
    public Canvas editQuestionCanvas;
    public Canvas playQuestionCanvas;
    public ImageLoader imgLdr;
    public GameObject testVisualAidButton;
    God god;

    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.Find("God").GetComponent<God>();
        switch(god.currentPlayMode)
        {
            case God.Mode.Edit:
                editQuestionCanvas.gameObject.SetActive(true);
                if (!god.currentQuestion.imageLink.Equals("")) imageURLInputField.text = god.currentQuestion.imageLink;
                if (!god.currentQuestion.question.Equals("")) questionInputField.text = god.currentQuestion.question;
                if (!god.currentQuestion.answer.Equals("")) answerInputField.text = god.currentQuestion.answer;
                Debug.Log(god);
                Debug.Log(answerInputField);
                break;
            case God.Mode.Play:
                playQuestionCanvas.gameObject.SetActive(true);
                imgLdr.SetImageFromWebInput(god.currentQuestion.imageLink);
                questionTextBox.text = god.currentQuestion.question;
                playVisualAid.color = Color.clear;
                god.currentQuestion.answered = true;
                answerTextBox.text = god.currentQuestion.answer;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        editVisualAid.gameObject.SetActive(god.currentQuestion.useVisualAid);
        imageURLInputField.gameObject.SetActive(god.currentQuestion.useVisualAid);
        testVisualAidButton.SetActive(god.currentQuestion.useVisualAid);
        playVisualAid.gameObject.SetActive(god.currentQuestion.useVisualAid);
        answerTextBox.gameObject.SetActive(revealAnswer.isOn);
    }

    public void ToggleVisualAid()
    {
        god.currentQuestion.useVisualAid = !god.currentQuestion.useVisualAid;
    }

    public void SaveQuestion()
    {
        god.currentQuestion.imageLink = imageURLInputField.text;
        god.currentQuestion.question = questionInputField.text;
        god.currentQuestion.answer = answerInputField.text;
        SaveSystem.SaveGame(god);
    }

    public void SetAnswered(bool answered)
    {
        god.currentQuestion.answered = answered;
    }

}
