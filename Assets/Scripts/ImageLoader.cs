using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    public Image img;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImageFromWebOnClick()
    {
        StartCoroutine(SetImageFromWeb(input.text));
    }

    public void SetImageFromWebInput(string url)
    {
        StartCoroutine(SetImageFromWeb(url));
    }

    IEnumerator SetImageFromWeb(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                if (input != null)
                {
                    input.text = uwr.error;
                    img.color = Color.red;
                }
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                img.preserveAspect = true;
                img.color = Color.white;
            }
        }
    }

}
