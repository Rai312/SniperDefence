using UnityEngine;

public class DiedState : IUnitState
{
    private Unit _unit;

    public DiedState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log("Die - Enter");
    }

    public void Exit()
    {
        Debug.Log("Die - Exit");
    }

    public void FixedUpdate()
    {
    }
}
