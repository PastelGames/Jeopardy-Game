using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("God").GetComponent<God>().SetModeEdit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
