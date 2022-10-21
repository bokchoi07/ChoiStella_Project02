using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GameState
{
    public override void Enter()
    {
        Debug.Log("player can move: enter ...");
    }

    public override void Exit()
    {
        Debug.Log("player can no longer move: ... exit");
    }
}
