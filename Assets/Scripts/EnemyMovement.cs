using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject food;
    private int totalFoodCount = 0;

    public int enemyFoodCount = 0;
    public float speed = 1.0f;
    public bool isThereFood = true;


    private void Start()
    {
        SetNewTarget();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // finding new target
        if (food == null)
        {
            enemyFoodCount++;
            SetNewTarget();
        }

        if (isThereFood)
        {
            transform.position = Vector3.MoveTowards(transform.position, food.transform.position, speed * Time.deltaTime);
        }
    }

    public void SetNewTarget()
    {
        //targets = GameObject.FindGameObjectsWithTag("Food");
        //Debug.Log("length of targets: " + targets.Length);
        //food = targets[0];
        if (GameObject.FindGameObjectWithTag("Food") != null)
        {
            food = GameObject.FindGameObjectWithTag("Food");
        }
        
        //totalFoodCount = GameObject.FindGameObjectsWithTag("Food").Length;
        

        if(food == null)
        {
            isThereFood = false;
        }
    }

    public GameObject GetNewTarget()
    {
        return food;
    }

    public void SetFoodCount(int count)
    {
        enemyFoodCount = count;
    }

    public int GetFoodCount()
    {
        return enemyFoodCount;
    }

    public int GetTotalFoodCount()
    {
        return totalFoodCount;
    }

    /*private GameObject target;
    public float speed = 1.0f;
    

    private void Update()
    {
        if(target == null)
        {
            FindNewTarget();
            Debug.Log("new target: " + target.name);
        }
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void FindNewTarget()
    {
        target = GameObject.FindGameObjectWithTag("Food");
    }*/
}
