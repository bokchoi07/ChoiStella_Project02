using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };

    //[SerializeField] float pauseDuration = 1.5f;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] FoodCount _foodCount;
    [SerializeField] Text enemyFoodCountTextUI = null;

    private int numPickup;
    private int tempTotalCount;

    public override void Enter()
    {
        EnemyTurnBegan?.Invoke(); // "enemy turn" text

        // "ai logic"; hardcoded win scenarios for the enemy
        if (_foodCount.GetFoodCount() == 5 || _foodCount.GetFoodCount() == 2)
        {
            Debug.Log("guaranteed win for enemy!");
            numPickup = 2;
        }
        else if(_foodCount.GetFoodCount() == 4)
        {
            numPickup = 1;
            Debug.Log("guaranteed win for enemy!");
        }
        else
        {
            numPickup = UnityEngine.Random.Range(1, 3);
        }

        enemyFoodCountTextUI.text = numPickup.ToString();
        tempTotalCount = _foodCount.GetFoodCount();

        Debug.Log("enemy turn entering; enemy will pick up " + numPickup);
        enemyMovement.enabled = true;

        //StartCoroutine(EnemyThinkingRoutine(pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("enemy turn: exit...");
        enemyMovement.enabled = false;
        EnemyTurnEnded?.Invoke();
    }

    public override void Tick()
    {
        // it's enemy turn and they pick up last food = player loses
        if(enemyMovement.isThereFood == false && _foodCount.GetFoodCount() == 0)
        {
            StateMachine.ChangeState<LoseState>();
        }

        // enemy finished eating # of food; go back to player's turn
        if(_foodCount.GetFoodCount() == tempTotalCount - numPickup && _foodCount.GetFoodCount() != 0)
        {
            enemyMovement.enabled = false;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    /*IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);
        
        EnemyTurnEnded?.Invoke();
        // turn over. go back to player
        StateMachine.ChangeState<PlayerTurnGameState>();
    }*/
}
