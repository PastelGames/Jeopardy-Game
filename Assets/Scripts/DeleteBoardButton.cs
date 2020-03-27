using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteBoardButton : MonoBehaviour
{

    God god;
    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.Find("God").GetComponent<God>();
        GetComponent<Button>().onClick.AddListener(god.DeleteBoard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
