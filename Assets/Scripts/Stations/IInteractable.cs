using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    GameObject pickupItem(GameObject player, bool hasFood, GameObject item);
}
