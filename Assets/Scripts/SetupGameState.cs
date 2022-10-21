using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameState : GameState
{
    [SerializeField] int startingCardNumber = 10;
    [SerializeField] int numberOfPlayers = 2;

    bool activated = false;
    public override void Enter()
    {
        Debug.Log("setup: ...entering");
        Debug.Log("creating " + numberOfPlayers + " players");
        Debug.Log("creating deck with " + startingCardNumber + " cards.");
        // cant change state while still in enter/exit() transition!
        // dont put ChangeState<> here

        activated = false;
    }

    public override void Tick()
    {
        if (activated == false)
        {
            activated = true;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    public override void Exit()
    {
        activated = false;
        Debug.Log("setup: exiting...");
    }
}
