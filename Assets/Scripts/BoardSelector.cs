using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSelector : MonoBehaviour
{
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        God god = GameObject.Find("God").GetComponent<God>();
        SceneSwapper sceneSwapper = GameObject.Find("SceneSwapper").GetComponent<SceneSwapper>();

        foreach (BoardData boardData in god.gameData.boards)
        {
            GameObject newButton = Instantiate(button, transform);
            newButton.GetComponentInChildren<Text>().text = boardData.boardName;
            newButton.GetComponent<Button>().onClick.AddListener(delegate { god.SetCurrentBoard(newButton.transform.GetSiblingIndex()); });
            newButton.GetComponent<Button>().onClick.AddListener(delegate { sceneSwapper.GoToScene("Board"); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
