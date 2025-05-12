using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item, bool isStack, bool isSlice, bool isPlate)
    {
        player.GetComponent<playerInteraction>().DestroyItem();
        return null;
    }
    public void Interact(GameObject player)
    {

    }
}
