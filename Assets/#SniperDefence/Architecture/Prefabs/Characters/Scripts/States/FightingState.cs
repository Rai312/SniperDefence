using UnityEngine;

namespace UnitState
{
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
            if (_unit is Enemy)
            {
                //Debug.Log("Fighting - Enter - " + _unit);
            }
            _timeToAttack = 0.2f;

            _unit.transform.LookAt(_unit.Target.transform.position);

            _unit.UnitAnimator.ShowAttack();
        }

        public void Exit()
        {
            _unit.UnitAnimator.ResetTrigger();
            if (_unit is Enemy)
            {
                // Debug.Log("ASDASDSAD");
                Enemy enemy = (Enemy)_unit;
                enemy.MoveToFinish();
                //Debug.Log("Fighting - Exit - " + _unit);
            }
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
}
