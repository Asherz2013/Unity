using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};


    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action currentAction = new Action();

        foreach(int pinFall in pinFalls)
        {
            currentAction = actionMaster.Bowl(pinFall);
        }

        return currentAction;
    }


    private int[] bowls = new int[21];
    private int bowl = 1;

    private Action Bowl (int Pins)
    {
        if(Pins < 0 || Pins > 10) throw new UnityException("Pins are not between 0 and 10!");

        bowls[bowl - 1] = Pins;
        
        if(bowl==21)
        {
            return Action.EndGame;
        }

        // Hand last-frame Special Cases
        if (bowl >= 19 && Pins == 10)
        {
            bowl++;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl++;
            if(bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
            {
                return Action.Tidy;
            }
            else if ( (bowls[19 - 1] + bowls[20 - 1]) == 10 )
            {
                return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }
                
        // First bowl of frame
        if(bowl % 2 != 0)
        {
            if(Pins==10)
            {
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl++;
                return Action.Tidy;
            }
        }
        // Second bowl of frame
        else if(bowl % 2 == 0)
        {
            bowl++;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }

    public bool Bowl21Awarded()
    {
        // Arrays are always ZERO based
        return (bowls[19 - 1] + bowls[20 - 1]) >= 10;
    }
}
