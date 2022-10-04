using UnityEngine;

public class FightingState : IUnitState
{
    private Unit _unit;

    public FightingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log("Fighting - Enter");
    }

    public void Exit()
    {
        Debug.Log("Fighting - Exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
