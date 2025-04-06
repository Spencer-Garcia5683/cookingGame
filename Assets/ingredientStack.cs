using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientStack : MonoBehaviour
{
    public int MAX = 4;
    public GameObject[] ingredients;
    public Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        //positions[0] = ingredients[0].transform.position;
        //positions[1] = ingredients[1].transform.position;
        //positions[2] = ingredients[2].transform.position;
        //positions[3] = ingredients[3].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getFromStack()
    {
        if (ingredients[3] != null)
        {
            GameObject temp = ingredients[3];
            ingredients[3] = null;
            return temp;
        }
        if (ingredients[2] != null)
        {
            GameObject temp = ingredients[2];
            ingredients[2] = null;
            return temp;
        }
        if (ingredients[1] != null)
        {
            GameObject temp = ingredients[1];
            ingredients[1] = null;
            return temp;
        }
        if (ingredients[0] != null)
        {
            GameObject temp = ingredients[0];
            ingredients[0] = null;
            return temp;
        }

        return null;
    }

    public void placeOnStack(GameObject newItem)
    {
        if (ingredients[3] == null)
        {
            ingredients[3] = newItem;
            ingredients[3].transform.position = positions[3];
        }
        if (ingredients[2] == null)
        {
            ingredients[2]  = newItem;
            ingredients[3].transform.position = positions[3];
        }
        if (ingredients[1] == null)
        {
            ingredients[1] = newItem;
            ingredients[3].transform.position = positions[3];
        }
        if (ingredients[0] == null)
        {
            ingredients[0] = newItem;
            ingredients[3].transform.position = positions[3];
        }
    }

    
   }
