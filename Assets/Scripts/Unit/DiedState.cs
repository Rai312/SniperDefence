public class DiedState : IUnitState
{
    private Unit _unit;

    public DiedState(Unit unit)
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
