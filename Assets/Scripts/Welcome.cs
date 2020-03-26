using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SceneSwapper").GetComponent<SceneSwapper>().SetButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
