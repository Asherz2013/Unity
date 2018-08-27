using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;

    private ScoreDisplay scoreDisplay;

    // Use this for initialization
    void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl (int pinFall)
    {
        rolls.Add(pinFall);
        ball.Reset();
        
        pinSetter.PerformAction(ActionMaster.NextAction(rolls));

        scoreDisplay.FillRolls(rolls);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
    }
}
