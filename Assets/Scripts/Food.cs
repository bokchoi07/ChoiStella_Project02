using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    [SerializeField] AudioClip eatingSFX;
    [SerializeField] GameObject eatingParticleSystem;
    [SerializeField] FoodCount _foodCount;

    public void OnTriggerEnter(Collider other)
    {
        if(eatingParticleSystem != null)
        {
            GameObject tempParticles = Instantiate(eatingParticleSystem, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(tempParticles, .7f);
        }
        if(eatingSFX != null)
        {
            AudioHelper.PlayClip2D(eatingSFX, .7f);
        }
        _foodCount.DecreaseTotalFoodCount();
        
        Destroy(gameObject);
    }
}
