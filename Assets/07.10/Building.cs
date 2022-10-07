using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Target
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _takeDamageEffect;
    [SerializeField] private ParticleSystem _destroyEffect;

    private bool _isAlive = true;
    //public override event Action<Target> Died;

    public override void TakeDamage(float damage)
    {
        if (_isAlive)
        {
            _health -= damage;
            if (_takeDamageEffect != null) _takeDamageEffect.Play();
            if (_health <= 0)
            {
                _isAlive = false;
                Die();
                //Died?.Invoke(this);
            }
        }
    }

    private void Die()
    {
        if (_destroyEffect != null)
        {
            _destroyEffect.transform.parent = null;
            _destroyEffect.Play();
        }
    }
}

