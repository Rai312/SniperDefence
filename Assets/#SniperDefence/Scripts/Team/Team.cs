using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    
    public IReadOnlyList<Unit> Units => _units;
    public bool IsAlive { get; private set; } = true;
    
    public void AddSpawned(DefenderSquad defenderSquat)
    {
        var defenders = defenderSquat.GetComponentsInChildren<Defender>();

        for (int i = 0; i < defenders.Length; i++)
        {
            _units.Add(defenders[i]);
        }
    }
    
    public bool CheckLose()
    {
        foreach (var unit in _units)
        {
            if (unit.IsAlive)
                return false;
        }

        return true;
    }
}