public class WaitingState : IUnitState
{
    private Unit _unit;

    public WaitingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
