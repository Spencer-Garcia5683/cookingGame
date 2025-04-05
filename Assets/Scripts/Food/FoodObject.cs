using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public FoodItem foodData;

    public string GetFoodName()
    {
        return foodData != null ? foodData.foodName : "Unknown";
    }
}
