using UnityEngine;

namespace UnitState
{
    public class DiedState : IUnitState
    {
        private Unit _unit;

        public DiedState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit is Unit)
            {
                //Debug.Log("DieState - Enter" + this);
            }
            //_unit.DeathParticle.Play();
            //_unit.NavMeshAgent.enabled = false;
            _unit.gameObject.SetActive(false);
        }

        public void Exit()
        {
            if (_unit is Unit)
            {
                Debug.Log("DieState - Exit" + this);

            }
        }

        public void FixedUpdate()
        {
        }
    }
}
