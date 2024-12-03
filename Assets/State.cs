using UnityEngine;

public abstract class State
{
    protected GameObject owner;

    public State(GameObject owner)
    {
        this.owner = owner;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
