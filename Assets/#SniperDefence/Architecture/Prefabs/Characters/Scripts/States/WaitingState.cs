using UnityEngine;

namespace UnitState
{
    public class WaitingState : IUnitState
    {
        private Unit _unit;

        public WaitingState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit is Enemy)
            {
                //Debug.Log("WaitingState - Enter - " + _unit);
            }
            _unit.UnitAnimator.ShowIdle();
            if (_unit is Enemy)
            {
                Enemy enemy = (Enemy)_unit;
                enemy.MoveToFinish();
                enemy.NavMeshAgent.speed = 3f;
            }
        }

        public void Exit()
        {
            if (_unit is Enemy)
            {
                //Debug.Log("WaitingState - Exit - " + _unit);
            }
            _unit.UnitAnimator.ResetTrigger();
        }

        public void FixedUpdate()
        {
            _unit.CheckDistanceToEnemy();
        }
    }
}
