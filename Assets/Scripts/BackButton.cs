using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject sceneSwapper = GameObject.Find("SceneSwapper");
        gameObject.GetComponent<Button>().onClick.AddListener(sceneSwapper.GetComponent<SceneSwapper>().ReturnToPreviousScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
