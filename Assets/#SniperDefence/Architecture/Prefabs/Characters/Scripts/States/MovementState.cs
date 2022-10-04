using UnityEngine;

public class MovementState : IUnitState
{
    private Unit _unit;

    public MovementState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log("Move - Enter");
        _unit.NavMeshAgent.enabled = true;
        //_unit.UnitAnimator.SetTrigger()
    }

    public void Exit()
    {
        Debug.Log("Move - Exit");
        _unit.NavMeshAgent.enabled = false;
    }

    public void Update()
    {
        _unit.NavMeshAgent.SetDestination(_unit.Target.transform.position);
        if (Vector3.Distance(_unit.transform.position, _unit.Target.transform.position) < _unit.HitDistance)
            _unit.StartFighting();
    }
}
