using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };

    //[SerializeField] float pauseDuration = 1.5f;
    [SerializeField] EnemyMovement enemyMovement;

    private int numPickup;

    public override void Enter()
    {
        EnemyTurnBegan?.Invoke(); // "enemy turn" text
        enemyMovement.enabled = true;

        
        numPickup = UnityEngine.Random.Range(1, 3);
        

        Debug.Log("enemy turn entering; enemy will pick up " + numPickup);

        //StartCoroutine(EnemyThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("enemy turn: exit...");
        enemyMovement.SetFoodCount(0);
        enemyMovement.enabled = false;
        EnemyTurnEnded?.Invoke();
    }

    /*IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);
        
        EnemyTurnEnded?.Invoke();
        // turn over. go back to player
        StateMachine.ChangeState<PlayerTurnGameState>();
    }*/
    

    public override void Tick()
    {
        // it's enemy turn and they pick up last food = player loses
        if(enemyMovement.isThereFood == false)
        {
            StateMachine.ChangeState<LoseState>();
        }

        // there's still food left so go back to player's turn
        if(enemyMovement.GetFoodCount() == numPickup)
        {
            enemyMovement.enabled = false;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }
}
