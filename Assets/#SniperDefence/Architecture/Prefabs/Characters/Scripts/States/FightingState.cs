using UnityEngine;

public class FightingState : IUnitState
{
    private Unit _unit;
    private float _timeToAttack;

    public FightingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log("Fighting - Enter - " + this);
        _timeToAttack = 0.2f;
        _unit.transform.LookAt(_unit.transform.position);
        _unit.UnitAnimator.ShowAttack();
    }

    public void Exit()
    {
        _unit.UnitAnimator.ResetTrigger();
        Debug.Log("Fighting - Exit - " + this);
    }

    public void FixedUpdate()
    {
        // if (_timeToAttack <= 0)
        // {
        //     _unit.HitTarget();
        //     _timeToAttack = _unit.AttackDuration;
        // }
        // _timeToAttack -= Time.deltaTime;
    }
}
