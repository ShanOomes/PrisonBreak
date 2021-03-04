using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInterface : MonoBehaviour, IInteractable
{
    public bool Solved = false;
    private bool toggle;

    public GameObject canvas;

    public Text title;
    public Text question;
    public Text answers;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        toggle = !toggle;
        if (toggle)
        {
            PuzzleItem trivia = APIManager.Instance.GetTrivia();
            if (trivia != null)
            {
                string temp;
                title.text = trivia.Name;
                question.text = trivia.GetQuestion();
                temp = trivia.GetAnswersList()[0] + ", " + trivia.GetAnswersList()[1] + ", " + trivia.GetAnswersList()[2] + ", " + trivia.GetAnswersList()[3];
                answers.text = temp;
                print(trivia.GetCorrectAnswer());
            }
            else
            {
                Debug.LogError("Trivia is null");
            }
            canvas.SetActive(true);
            GameManager.Instance.ToggleInterface();
        }
        else
        {
            canvas.SetActive(false);
            GameManager.Instance.ToggleInterface();
        }
    }
}
