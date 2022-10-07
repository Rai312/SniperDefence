using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    public abstract void TakeDamage(float damage);
    //public abstract event Action<Target> Died;
}
