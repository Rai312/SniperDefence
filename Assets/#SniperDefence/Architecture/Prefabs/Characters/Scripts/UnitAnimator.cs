using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Attack = nameof(Attack);

    [SerializeField] private Animator _animator;
    [SerializeField] private Unit _unit;

    public Animator Animator => _animator;

    public void ShowIdle()
    {
        _animator.SetTrigger(Idle);
    }

    public void ShowAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void ShowRun()
    {
        _animator.SetTrigger(Run);
    }

    public void ResetTrigger()
    {
        _animator.ResetTrigger(Idle);
        _animator.ResetTrigger(Attack);
        _animator.ResetTrigger(Run);
    }

    private void HandleHitTarget()
    {
        _unit.HitTarget();
    }
}
