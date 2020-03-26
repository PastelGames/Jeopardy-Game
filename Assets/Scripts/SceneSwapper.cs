using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwapper : MonoBehaviour
{

    public Stack<int> visitedScenes;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        visitedScenes = new Stack<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(int index)
    {
        visitedScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(index);
    }

    public void GoToScene(string name)
    {
        visitedScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(name);
        SetButtons();
    }

    public void SetButtons()
    {
        GameObject[] buttonsInScene = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttonsInScene)
        {
            string sceneToGoTo = button.GetComponent<ButtonData>().sceneToGoToString;
            button.GetComponent<Button>().onClick.AddListener(delegate { GoToScene(sceneToGoTo); });
        }
    }

    public void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(visitedScenes.Pop());
    }
}
