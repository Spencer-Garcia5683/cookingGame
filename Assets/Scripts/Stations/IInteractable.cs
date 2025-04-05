using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject pickupItem(GameObject player, bool hasFood, GameObject item);
    public void Interact();
}
