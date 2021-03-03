using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    private string question;
    private string correct_answer;
    private List<string> answers = new List<string>();
    private bool solved;

    //Propertie
    public string Question { get { return this.question; } set { this.question = value; } }
    public string Answer { get { return this.correct_answer; } set { this.correct_answer = value; } }
    public bool Solved { get { return this.solved; } set { this.solved = value; } }

    //Standard constructor
    public PuzzleItem()
        : base()
    {
        this.question = "";
        this.correct_answer = "";
    }

    //Custom constructor
    public PuzzleItem(string question, string correct_answer, string name, float weight)
        : base(name, weight)
    {
        this.question = question;
        this.correct_answer = correct_answer;
        solved = false;
    }

    public string GetQuestion()
    {
        return question;
    }

    public string GetCorrectAnswer()
    {
        return correct_answer;
    }

    public bool IsSolved()
    {
        return solved;
    }

    public bool Reset()
    {
        return solved = false;
    }

    public bool CheckAnswer(string playerInput)
    {
        if (playerInput == this.correct_answer)
        {
            solved = true;
            return true;
        }
        return false;
    }

    public void AddAnswer(string i)
    {
        answers.Add(i);
    }

    public List<string> GetList()
    {
        return answers;
    }

    public int GetCount()
    {
        return answers.Count;
    }

    public void DebugAnswersList()
    {
        foreach (var i in answers)
        {
            Debug.Log(i);
        }
    }
}
