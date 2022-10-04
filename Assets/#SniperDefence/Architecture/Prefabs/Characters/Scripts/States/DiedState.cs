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
        _unit.gameObject.SetActive(false);
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }
}
