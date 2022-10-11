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
    [SerializeField] private float _targetDistance;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _deathParticle;

    private int _currentHealth;
    private IReadOnlyList<Unit> _targets;
    private Unit _target;

    public bool IsAlive { get; private set; }
    public float HitDistance => _hitDistance;
    public ParticleSystem DeathParticle => _deathParticle;
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
        //if (_targets != null)
        //    _target.Died -= OnTargetDied;
    }

    public void SetTarget()
    {
        _target = GetTarget();
        if (_target == null)
        {
            Waiting?.Invoke();
            return;
        }
        _target.Died += OnTargetDied;
        TargetAssigned?.Invoke();
    }

    public void Damage(int damage)
    {
        if (damage < _currentHealth)
            _currentHealth -= damage;
        else
        {
            IsAlive = false;
            _currentHealth = 0;

            if (_target != null)
                _target.Died -= OnTargetDied;

            Died?.Invoke();
        }
    }

    public virtual void HitTarget()
    {
        if (_target != null)
        {
            if (_target.Health <= 0)
            {
                //TargetAssigned?.Invoke();
                Waiting.Invoke();
            }
            else
                _target.Damage(_damage);
        }

    }

    public void StartFighting()
    {
        Fight?.Invoke();
    }

    public void CheckDistanceToEnemy()
    {
        if (this is Enemy)
        {
         //   Debug.Log("CheckDistanceToEnemy");
        }

        for (int i = 0; i < _targets.Count; i++)
        {
            if (this is Enemy)
            {
                if (_targets[i] is Defender)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);

                    if (distanceToTarget < _targetDistance && _targets[i].IsAlive)
                    {
                        TargetSearching?.Invoke();
                    }
                }
            }
            else if (this is Defender)
            {
                if (_targets[i] is Enemy)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);

                    if (distanceToTarget < _targetDistance && _targets[i].IsAlive)
                    {
                        TargetSearching?.Invoke();
                    }
                }
            }
        }
    }

    public void SetDie()
    {
        Died?.Invoke();
    }

    public void SetWaiting()
    {
        Waiting?.Invoke();
    }

    private Unit GetTarget()//DUPLICATE
    {
        if (this is Enemy)
        {
            Unit nearestTarget = null;
            float distanceToNearestTarget = float.MaxValue;
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i] is Defender && _targets[i].IsAlive)
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
                if (_targets[i] is Enemy && _targets[i].IsAlive)
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

    public virtual void OnTargetDied()
    {
        _target.Died -= OnTargetDied;
        //TargetSearching?.Invoke();
        Waiting?.Invoke();
    }

    //The Event in Animation
    private void HandleDieAnimation()
    {
        gameObject.SetActive(false);
    }
}
