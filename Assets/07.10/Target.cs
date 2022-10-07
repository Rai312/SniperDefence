using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;

    public bool IsAlive { get; set; }

    public abstract event Action Died;

    public abstract void TakeDamage(int damage);
    public abstract void Initialize(IReadOnlyList<Target> enemies);
}
