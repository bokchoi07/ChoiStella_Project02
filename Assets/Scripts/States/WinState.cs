using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : GameState
{
    // if player takes last piece(s) they win! prompt play again, main menu, or exit game

    public override void Enter()
    {
        Debug.Log("win state entered... player has won!");
        Debug.Log("prompt actions - play again, menu, exit");
    }

    public override void Exit()
    {
        Debug.Log("exiting win state");
    }
}
