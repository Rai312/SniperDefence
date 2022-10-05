using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private ContainerFinishPoints _containerFinishPoints;

    private FinishPoint[] _finishPoints;
    private FinishPoint _finishPoint;

    private void Awake()
    {
        _finishPoints = _containerFinishPoints.GetComponentsInChildren<FinishPoint>();
        _finishPoint = _finishPoints[0];
    }

    public override void StartBattle()
    {

        base.StartBattle();
    }

    public void MoveToFinish()
    {
        NavMeshAgent.SetDestination(_finishPoint.transform.position);
    }

    public override void TrySetTarget()
    {

        base.TrySetTarget();
    }
}
