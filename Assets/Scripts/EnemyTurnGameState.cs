using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };

    [SerializeField] float pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("enemy turn: ...enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("enemy turn: exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("enemy performs action");
        EnemyTurnEnded?.Invoke();
        // turn over. go back to player
        StateMachine.ChangeState<PlayerTurnGameState>();
    }
}
