using UnityEngine;
using System.Collections;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};

    public Action Bowl (int Pins)
    {
        if(Pins < 0 || Pins > 10) throw new UnityException("Pins are not between 0 and 10!");

        if (Pins == 10)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }
}
