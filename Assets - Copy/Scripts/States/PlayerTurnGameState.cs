using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text playerTurnTextUI = null;
    [SerializeField] Text playerFoodCountTextUI = null;
    [SerializeField] Text enterToEndTextUI = null;

    [SerializeField] PlayerMovement playerMovement = null;
    [SerializeField] FoodCount foodCount = null;


    int tempTotalFoodCount;


    public override void Enter()
    {
        Debug.Log("player turn: ...entering");
        playerFoodCountTextUI.text = "player's turn: 2";

        playerTurnTextUI.gameObject.SetActive(true);
        enterToEndTextUI.gameObject.SetActive(true);
        playerMovement.enabled = true;

        tempTotalFoodCount = foodCount.GetFoodCount();

        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        playerTurnTextUI.gameObject.SetActive(false);
        enterToEndTextUI.gameObject.SetActive(false);
        playerMovement.enabled = false;

        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        Debug.Log("player turn: exiting...");
    }

    public override void Tick()
    {
        if (foodCount.GetFoodCount() == tempTotalFoodCount - 1)
        {
            playerFoodCountTextUI.text = "player's turn: 1";
        }
        if (foodCount.GetFoodCount() == tempTotalFoodCount - 2)
        {
            playerMovement.enabled = false;
            playerFoodCountTextUI.text = "player's turn: 0";
        }

        if (GameObject.FindGameObjectWithTag("Food") == null)
        {
            StateMachine.ChangeState<WinState>();
        }
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnGameState>();
    }
}
