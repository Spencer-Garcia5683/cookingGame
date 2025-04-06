using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    public GameObject plateObj, pattyObj, lettuceObj, cheeseObj, tomatoObj, bunTopObj, bunBottomObj;

    public GameObject topBunPrefab, bottomBunPrefab;

    public Vector3[] positions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placeIngredient(GameObject item, Vector3 pos)
    {
        print("rtunning place ingredient");
        switch(item.tag)
        {
            case "plate":
                plateObj = item;
                plateObj.transform.position = pos + positions[0];
                plateObj.transform.parent = gameObject.transform;
                break;
            case "cookedPatty":
                pattyObj = item;
                pattyObj.transform.position = pos + positions[2];
                pattyObj.transform.parent = gameObject.transform;
                break;
            case "lettuceSlice":
                print("placing lettuce");
                lettuceObj = item;
                lettuceObj.transform.position = pos + positions[4];
                lettuceObj.transform.parent = gameObject.transform;
                break;
            case "tomatoSlice":
                tomatoObj = item;
                tomatoObj.transform.position = pos + positions[5];
                tomatoObj.transform.parent = gameObject.transform;
                break;
            case "cheeseSlice":
                cheeseObj = item;
                cheeseObj.transform.position = pos + positions[3];
                cheeseObj.transform.parent = gameObject.transform;
                break;
            case "buns":
                bunTopObj = Instantiate(topBunPrefab, positions[6], Quaternion.identity);
                bunTopObj.transform.position = pos + positions[6];
                bunTopObj.transform.parent = gameObject.transform;
                bunBottomObj = Instantiate(bottomBunPrefab, positions[1], Quaternion.identity);
                bunBottomObj.transform.position = pos + positions[1];
                bunBottomObj.transform.parent = gameObject.transform;
                Destroy(item);
                break;
        }
    }

}
