using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{
    public GameObject cube;
    IEnumerator GetRequest(string url)
    {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    print("Checkout this funny joke: " + JsonObject["value"]["joke"].Value);
                    break;
            }
        }
    }

    IEnumerator GetRandomDog(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                JSONNode JsonObject = JSON.Parse(www.downloadHandler.text);
                print("Dog url: " + JsonObject["message"].Value);
                //cube.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                StartCoroutine(GetTexture(JsonObject["message"].Value));
            }
        }
    }

    IEnumerator GetTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                cube.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetRequest("http://api.icndb.com/jokes/random"));
        StartCoroutine(GetRandomDog("https://dog.ceo/api/breeds/image/random"));
        //StartCoroutine(GetRandomDog("https://api.thecatapi.com/v1/images/search"));
    }
}
