using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    private string riddle;
    private string answer;
    private bool solved;

    //Propertie
    public string Riddle { get { return this.riddle; } set { this.riddle = value; } }
    public string Answer { get { return this.answer; } set { this.answer = value; } }
    public bool Solved { get { return this.solved; } set { this.solved = value; } }

    //Standard constructor
    public PuzzleItem()
        : base()
    {
        this.riddle = "";
        this.answer = "";
    }

    //Custom constructor
    public PuzzleItem(string riddle, string answer, string name, float weight)
        : base(name, weight)
    {
        this.riddle = riddle;
        this.answer = answer;
        solved = false;
    }

    public string GetRiddle()
    {
        return riddle;
    }

    public string GetAnswer()
    {
        return answer;
    }

    public bool IsSolved()
    {
        return solved;
    }

    public bool Reset()
    {
        return solved = false;
    }

    public bool CheckAnswer(string answer)
    {
        if (answer == this.answer)
        {
            solved = true;
            return true;
        }
        return false;
    }
}
