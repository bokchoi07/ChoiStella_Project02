using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("enemy has won! play again or quit?");
        // display smth to play again/main menu/quit
    }
}
