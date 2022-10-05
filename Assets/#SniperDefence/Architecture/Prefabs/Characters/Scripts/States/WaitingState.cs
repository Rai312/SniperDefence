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
        Debug.Log("WaitingState - Enter");
        _unit.UnitAnimator.ShowIdle();
        if (_unit is Enemy)
        {
            Enemy enemy = (Enemy)_unit;
            enemy.MoveToFinish();
        }
    }

    public void Exit()
    {
        Debug.Log("WaitingState - Exit");
        _unit.UnitAnimator.ResetTrigger();
    }

    public void FixedUpdate()
    {
        _unit.CheckDistanceToEnemy();
    }
}
