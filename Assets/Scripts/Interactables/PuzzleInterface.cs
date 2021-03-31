using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleInterface : MonoBehaviour, IInteractable
{
    public bool Solved = false;
    private bool toggle;

    public GameObject canvas;

    public TextMeshProUGUI title;
    public TextMeshProUGUI question;
    public TextMeshProUGUI answers;
    public TMP_InputField userInput;
    private PuzzleItem trivia;
    private PlayerManager fps;
    public HingeDoor door;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        trivia = APIManager.Instance.GetTrivia();
    }

    public void Action(PlayerManager player)
    {
        toggle = !toggle;
        if (toggle)
        {

            trivia = APIManager.Instance.GetTrivia();
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

    public void SubmitAnswer()
    {
        if(userInput.text != null)
        {
            if (userInput.text == trivia.GetCorrectAnswer())
            {
                Solved = true;
                door.open = true;
            }
        }
    }

    public void isTyping()
    {
        fps.isTyping = true;
    }

    public void stoppedTyping()
    {
        fps.isTyping = false;
    }
}
