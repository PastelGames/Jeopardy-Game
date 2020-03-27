using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public Text questionTextBox;
    public Image playVisualAid;
    public Image editVisualAid;
    public string imageURL;
    public InputField questionInputField;
    public InputField imageURLInputField;
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
                break;
            case God.Mode.Play:
                playQuestionCanvas.gameObject.SetActive(true);
                imgLdr.SetImageFromWebInput(god.currentQuestion.imageLink);
                questionTextBox.text = god.currentQuestion.question;
                playVisualAid.color = Color.clear;
                god.currentQuestion.answered = true;
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
    }

    public void ToggleVisualAid()
    {
        god.currentQuestion.useVisualAid = !god.currentQuestion.useVisualAid;
    }

    public void SaveQuestion()
    {
        god.currentQuestion.imageLink = imageURLInputField.text;
        god.currentQuestion.question = questionInputField.text;
        SaveSystem.SaveGame(god);
    }

    public void SetAnswered(bool answered)
    {
        god.currentQuestion.answered = answered;
    }

}
