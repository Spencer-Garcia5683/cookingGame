using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFoodItem", menuName = "Food/Food Item")]

public class FoodItem: ScriptableObject
{
    public string foodName;
    public GameObject icon;
    public List<ScriptableObject> canPlaceOn;


}
