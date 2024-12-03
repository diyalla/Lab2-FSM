using UnityEngine;

public class RestState : State
{
    private float restDuration;
    private float restStartTime;

    public RestState(GameObject owner, float restDuration) : base(owner)
    {
        this.restDuration = restDuration;
    }

    public override void Enter()
    {
        Debug.Log("Entering Rest State");
        restStartTime = Time.time;
    }

    public override void Execute()
    {
        if (Time.time - restStartTime >= restDuration)
        {
            // Transition back to patrol (example)
            owner.GetComponent<FSM>().ChangeState(new PatrolState(owner, GameManager.Instance.Waypoints));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Rest State");
    }
}
