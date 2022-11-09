using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text playerTurnTextUI = null;
    [SerializeField] PlayerMovement playerMovement = null;


    public override void Enter()
    {
        Debug.Log("player turn: ...entering");
        playerTurnTextUI.gameObject.SetActive(true);
        playerMovement.enabled = true;
        //playerTurnCount++;
        //playerTurnTextUI.text = "player turn: " + playerTurnCount.ToString();

        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        playerTurnTextUI.gameObject.SetActive(false);
        playerMovement.enabled = false;

        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        Debug.Log("player turn: exiting...");
    }

    public override void Tick()
    {
        if(GameObject.FindGameObjectWithTag("Food") == null)
        {
            StateMachine.ChangeState<WinState>();
        }
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnGameState>();
    }
}
