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
        Debug.Log("Fighting - Enter");
        _timeToAttack = 0.2f;
        _unit.transform.LookAt(_unit.transform.position);
    }

    public void Exit()
    {
        Debug.Log("Fighting - Exit");
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
