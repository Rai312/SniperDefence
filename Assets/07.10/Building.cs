using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Target
{
    public override event Action Died;

    public override void Initialize(IReadOnlyList<Target> enemies) { }

    public override void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
