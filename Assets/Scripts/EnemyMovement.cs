using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject food;
    public int foodCount = 0;
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
        if (food == null)
        {
            foodCount++;
            SetNewTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, food.transform.position, speed * Time.deltaTime);
    }

    public void SetNewTarget()
    {
        //targets = GameObject.FindGameObjectsWithTag("Food");
        //Debug.Log("length of targets: " + targets.Length);
        //food = targets[0];
        food = GameObject.FindGameObjectWithTag("Food");

        if(food == null)
        {
            Debug.Log("there is no more food, trigger win/lose state");
            isThereFood = false;
        }
    }

    public GameObject GetNewTarget()
    {
        return food;
    }

    public void SetFoodCount(int count)
    {
        foodCount = count;
    }

    public int GetFoodCount()
    {
        return foodCount;
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
