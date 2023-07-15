using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSM : StateMachine
{
    [SerializeField] InputController input;
    public InputController Input => input;

    void Start()
    {
        ChangeState<SetupGameState>();
    }
}
