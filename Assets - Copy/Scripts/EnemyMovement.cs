using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    private GameObject food;

    public float speed = 1.0f;
    public bool isThereFood = true;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // finding new target
        if (food == null)
        {
            SetNewTarget();
        }

        if (isThereFood)
        {
            transform.position = Vector3.MoveTowards(transform.position, food.transform.position, speed * Time.deltaTime);
        }
    }

    public void SetNewTarget()
    {
        if (GameObject.FindGameObjectWithTag("Food") != null)
        {
            food = GameObject.FindGameObjectWithTag("Food");
        }
        else
        {
            isThereFood = false;
        }
    }
}
