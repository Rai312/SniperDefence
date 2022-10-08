using UnityEngine;

namespace UnitState
{
    public class StartState : IUnitState
    {
        private readonly Unit _unit;

        public StartState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit is Enemy)
            {
                //Debug.Log("StartState - Enter - " + _unit);
            }
        }

        public void Exit()
        {
            if (_unit is Enemy)
            {
                //Debug.Log("StartState - Exit - " + _unit);
            }
        }

        public void FixedUpdate()
        {
        }
    }
}