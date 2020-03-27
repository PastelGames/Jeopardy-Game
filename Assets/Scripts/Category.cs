using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    public List<GameObject> questions;
    public Text categoryNameText;
    public InputField categoryInputField;
    God god;
    SceneSwapper ss;
    
    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.Find("God").GetComponent<God>();
        ss = GameObject.Find("SceneSwapper").GetComponent<SceneSwapper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulateQuestions(CategoryData data)
    {
        int firstIndexOfQuestion = 0;
        foreach(Transform child in transform)
        {
            if (child.CompareTag("Question"))
            {
                child.GetComponent<Button>().onClick.AddListener(delegate { god.SetCurrentQuestion(data.questions[child.GetSiblingIndex() - firstIndexOfQuestion]); });
                child.GetComponent<Button>().onClick.AddListener(delegate {
                    if (GameObject.Find("God").GetComponent<God>().currentPlayMode == God.Mode.Edit)
                    {
                        GameObject.Find("Board").GetComponent<Board>().SaveBoard();
                    }
                    ss.GoToScene("Question");
                });
            }
            else
            {
                firstIndexOfQuestion++;
            }
        }
    }
}
