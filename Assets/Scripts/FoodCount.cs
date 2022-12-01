using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCount : MonoBehaviour
{
    [SerializeField] Text foodCountTextUI = null;

    public int _foodCount = 21;

    public void DecreaseTotalFoodCount()
    {
        _foodCount--;
        foodCountTextUI.text = _foodCount.ToString();
    }

    public int GetFoodCount()
    {
        return _foodCount;
    }
}
