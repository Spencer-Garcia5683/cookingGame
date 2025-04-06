using UnityEngine;
using UnityEngine.AI;

public enum FoodType
{
    Burger,
    IceCream
}

public class customer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform targetSpot;
    private GameModeController controller;
    private int lineIndex;
    public FoodType desiredFood;

    public CustomerState state;

    public float checkRadius = 1f;

    public void Initialize(Transform destination, GameModeController gameController, int linePos)
    {
        agent = GetComponent<NavMeshAgent>();
        controller = gameController;
        lineIndex = linePos;

        MoveTo(destination);
        state = CustomerState.WalkingToLine;
    }

    private void Update()
    {
        Collider[] windows = Physics.OverlapSphere(transform.position + Vector3.up, checkRadius);
        foreach (Collider window in windows)
        {
            if (window.tag == "serve")
            {
                if (CheckPlateInWindow(window.gameObject.GetComponent<servingWindow>()))
                {
                    GameObject temp = GameObject.FindGameObjectWithTag("storeManager");
                    temp.GetComponent<StoreManager>().MakeSale(25);

                    window.GetComponent<servingWindow>().removeItem();

                    // After serving, remove the customer from the line
                    controller.RemoveCustomerFromLine(this);

                    Destroy(gameObject);
                }
            }
        }

        switch (state)
        {
            case CustomerState.WalkingToLine:
                if (HasReachedDestination())
                    state = CustomerState.WaitingInLine;
                break;

            case CustomerState.Ordering:
                // Handle ordering state here
                break;

            case CustomerState.WaitingForFood:
                // Handle waiting for food
                break;

            case CustomerState.WalkingToTable:
                if (HasReachedDestination())
                    state = CustomerState.Eating;
                break;

            case CustomerState.Eating:
                // Handle eating state here
                break;
        }
    }

    public void SetOrder(FoodType order)
    {
        desiredFood = order;
        Debug.Log($"Customer {name} wants {order}");
    }

    public bool CheckPlateInWindow(servingWindow window)
    {
        if (window.burgSlot != null)
            return true;

        if (desiredFood == FoodType.IceCream && window.iceCreamSlot.transform.childCount > 0)
            return true;

        return false;
    }

    public void MoveTo(Transform newTarget)
    {
        targetSpot = newTarget;
        agent.SetDestination(newTarget.position);
    }

    public bool HasReachedDestination()
    {
        if(agent == null) return false;
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public void AdvanceInLine(Transform nextSpot, int newIndex)
    {
        lineIndex = newIndex;
        MoveTo(nextSpot);
        state = CustomerState.WalkingToLine;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position + Vector3.up, checkRadius);
    }
}

public enum CustomerState
{
    WalkingToLine,
    WaitingInLine,
    Ordering,
    WaitingForFood,
    WalkingToTable,
    Eating
}
