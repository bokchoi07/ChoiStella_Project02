using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("eat food");
        Destroy(gameObject);
    }
}
