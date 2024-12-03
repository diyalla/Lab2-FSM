using UnityEngine;
using UnityEngine.AI;

public class FleeToHQState : State
{
    private NavMeshAgent agent;
    private Transform hqLocation;

    public FleeToHQState(GameObject owner, Transform hqLocation) : base(owner)
    {
        this.agent = owner.GetComponent<NavMeshAgent>();
        this.hqLocation = hqLocation;
    }

    public override void Enter()
    {
        Debug.Log("Fleeing to HQ");
        agent.destination = hqLocation.position;
    }

    public override void Execute()
    {
        if (Vector3.Distance(owner.transform.position, hqLocation.position) < 1f)
        {
            Debug.Log("Reached HQ, transitioning to Rest state");
            owner.GetComponent<FSM>().ChangeState(new RestState(owner, 5f));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting FleeToHQ State");
    }
}
