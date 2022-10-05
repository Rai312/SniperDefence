using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitAnimator _unitAnimator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _hitDistance;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private int _currentHealth;
    private IReadOnlyList<Unit> _targets;
    private Unit _target;

    public bool IsAlive { get; private set; }
    public float HitDistance => _hitDistance;
    public UnitAnimator UnitAnimator => _unitAnimator;
    public Unit Target => _target;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float Health => _health;

    public event Action Waiting;
    public event Action TargetSearching;
    public event Action TargetAssigned;
    public event Action Fight;
    public event Action Died;

    public void Initialize(IReadOnlyList<Unit> enemies)
    {
        if (enemies == null)
            throw new ArgumentNullException("Unit is not initialized by enemies.");
        _currentHealth = _health;
        _targets = enemies;
    }

    private void OnEnable()
    {
        IsAlive = true;
    }

    private void OnDisable()
    {
        if (_targets != null)
            _target.Died -= OnTargetDied;
    }

    //public abstract void SetAvatar();


    public void SetTarget()
    {
        _target = FindTarget();
        if (_target == null)
        {
            Waiting?.Invoke();
            return;
        }
        _target.Died += OnTargetDied;
        TargetAssigned?.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        if (damage < _currentHealth)
            _currentHealth -= damage;
        else
        {
            IsAlive = false;
            if (_target != null)
                _target.Died -= OnTargetDied;

            Died?.Invoke();
        }
    }

    public void HitTarget()
    {
        if (_target != null)
        {
            if (_target.Health <= 0)
                TargetAssigned?.Invoke();
            else
                _target.ApplyDamage(_damage);
        }

    }

    public void StartFighting()
    {
        Fight?.Invoke();
    }

    //public void StartBattle()
    //{
    //    TargetSearching?.Invoke();
    //}

    public virtual void StartBattle()
    {
        TargetSearching?.Invoke();
    }

    public void SetDie()
    {
        Died?.Invoke();
    }

    public void SetWaiting()
    {
        Waiting?.Invoke();
    }

    private Unit FindTarget()//DUPLICATE
    {
        if (this is Enemy)
        {
            Unit nearestTarget = null;
            float distanceToNearestTarget = float.MaxValue;
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i] is Defender)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);

                    if (distanceToTarget < distanceToNearestTarget)
                    {
                        nearestTarget = _targets[i];
                        distanceToNearestTarget = distanceToTarget;
                    }
                }
            }
            return nearestTarget;
        }
        else
        {
            Unit nearestTarget = null;
            float distanceToNearestTarget = float.MaxValue;
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i] is Enemy)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);

                    if (distanceToTarget < distanceToNearestTarget)
                    {
                        nearestTarget = _targets[i];
                        distanceToNearestTarget = distanceToTarget;
                    }
                }
            }
            return nearestTarget;
        }
    }

    private void OnTargetDied()
    {
        _target.Died -= OnTargetDied;
        TargetSearching?.Invoke();
    }

    //The Event in Animation
    private void HandleDieAnimation()
    {
        gameObject.SetActive(false);
    }
}
