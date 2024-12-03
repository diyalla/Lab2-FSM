using UnityEngine;

public class FSM : MonoBehaviour
{
    private State currentState;

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
