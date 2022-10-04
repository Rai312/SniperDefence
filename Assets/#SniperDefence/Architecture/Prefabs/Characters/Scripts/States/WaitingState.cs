using UnityEngine;

public class WaitingState : IUnitState
{
    private Unit _unit;

    public WaitingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        _unit.UnitAnimator.ShowIdle();
        //Debug.Log("WaitingState - Enter");
    }

    public void Exit()
    {
        _unit.UnitAnimator.ResetTrigger();
        //Debug.Log("WaitingState - Exit");
    }

    public void FixedUpdate()
    {
    }
}
