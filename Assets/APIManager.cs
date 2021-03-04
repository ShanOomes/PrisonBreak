using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
public class APIManager : MonoBehaviour
{
    private GameObject cube;
    private PuzzleItem puzzle;
    public static APIManager Instance;
    private bool completed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

                    puzzle = new PuzzleItem(JsonObject["results"][0]["question"].Value, JsonObject["results"][0]["correct_answer"].Value, "Game trivia", 1f);

                    //correct answer
                    puzzle.AddAnswer(JsonObject["results"][0]["correct_answer"].Value);

                    //incorrect answer
                    for (int i = 0; i < JsonObject["results"][0]["incorrect_answers"].Count; i++)
                    {
                        puzzle.AddAnswer(JsonObject["results"][0]["incorrect_answers"][i].Value);
                    }

                    //print answers
                    //print(puzzle.GetCount());
                    //print("Question: " + puzzle.GetQuestion());
                    //print("correct answer: " + puzzle.GetCorrectAnswer());
                    puzzle.GetList().Shuffle();
                    //print(puzzle.GetQuestion());
                    //puzzle.DebugAnswersList();
                    //print("Correct answer: " + puzzle.GetCorrectAnswer());
                    completed = true;
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
                //print("Dog url: " + JsonObject["message"].Value);
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
        //StartCoroutine(GetRandomDog("https://dog.ceo/api/breeds/image/random"));
        //StartCoroutine(GetRandomDog("https://api.thecatapi.com/v1/images/search"));
        
    }

    public PuzzleItem GetTrivia()
    {
        StartCoroutine(GetRequest("https://opentdb.com/api.php?amount=1&category=15&difficulty=medium&type=multiple"));
        if (completed)
        {
            return puzzle;
        }
        return null;
    }
}
