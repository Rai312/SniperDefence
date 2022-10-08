using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FenceState
{
    public class WaitingState : IFenceState
    {
        private readonly Fencing _fencing;

        public WaitingState(Fencing fencing)
        {
            _fencing = fencing;
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
