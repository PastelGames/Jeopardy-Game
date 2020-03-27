using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBoardButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //i got extremely lazy here
        GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("God").GetComponent<God>().ResetBoard(GameObject.Find("God").GetComponent<God>().currentBoard); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
