using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollTexts, frameTexts;

    public void FillRolls(List<int> rolls)
    {
        string output = FormatRolls(rolls);
        for (int i = 0; i < output.Length; i++)
        {
            rollTexts[i].text = output[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;

            if(rolls[i] == 0)
            {
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i-1] + rolls[i] == 10)
            {
                output += "/";
            }
            else if (rolls[i] == 10)
            {
                if(box < 19) output += "X ";
                else output += "X";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}
