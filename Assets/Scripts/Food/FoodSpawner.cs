using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public FoodItem[] availableFood;

    void Start()
    {
        
    }

    void Update()
    {
        //SpawnFood(availableFoods[0]); 
    }

    public void SpawnFood(FoodItem itemToSpawn)
    {
        GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        FoodObject foodObj = food.GetComponent<FoodObject>();
        foodObj.foodData = itemToSpawn;
    }
}
