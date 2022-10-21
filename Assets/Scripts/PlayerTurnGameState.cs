using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text playerTurnTextUI = null;

    int playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("player turn: ...entering");
        playerTurnTextUI.gameObject.SetActive(true);

        playerTurnCount++;
        playerTurnTextUI.text = "player turn: " + playerTurnCount.ToString();
    }

    public override void Exit()
    {
        playerTurnTextUI.gameObject.SetActive(false);
        Debug.Log("player turn: exiting...");
    }
}
