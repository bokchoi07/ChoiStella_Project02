using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };

    [SerializeField] float pauseDuration = 1.5f;
    [SerializeField] EnemyMovement enemyMovement;

    private int numPickup;

    public override void Enter()
    {
        EnemyTurnBegan?.Invoke(); // "enemy thinking" text

        numPickup = UnityEngine.Random.Range(1, 3);
        Debug.Log("enemy turn; enemy will pick up " + numPickup);

        enemyMovement.SetNewTarget();
        GrabFood();
        //StartCoroutine(EnemyThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("enemy turn: exit...");
        enemyMovement.SetFoodCount(0);
        enemyMovement.enabled = false;
    }

    /*IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);
        
        EnemyTurnEnded?.Invoke();
        // turn over. go back to player
        StateMachine.ChangeState<PlayerTurnGameState>();
    }*/
    private void GrabFood()
    {
        enemyMovement.enabled = true;
    }

    public override void Tick()
    {
        base.Tick();

        if(enemyMovement.isThereFood == false)
        {
            StateMachine.ChangeState<LoseState>();
        }

        if(enemyMovement.GetFoodCount() == numPickup)
        {
            enemyMovement.enabled = false;
            EnemyTurnEnded?.Invoke();
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }
}
