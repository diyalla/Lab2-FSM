using UnityEngine;

public class GuardController : MonoBehaviour
{
    private FSM fsm;

    public Transform[] waypoints;
    public Transform player;
    public Transform hqLocation;

    void Start()
    {
        fsm = GetComponent<FSM>();

        // Start with the Patrol state
        var patrolState = new PatrolState(gameObject, waypoints);
        fsm.ChangeState(patrolState);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 5f)
        {
            fsm.ChangeState(new ChaseState(gameObject, player));
        }
        else if (distanceToPlayer > 10f)
        {
            fsm.ChangeState(new FleeToHQState(gameObject, hqLocation));
        }
    }
}
