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

    public void RemoveDefendersMerge(DefenderSquad[] defenderSquads)
    {
        // тут надо удалить дефендеров
        if (this is TeamDefender)
        {
            for (int i = 0; i < defenderSquads.Length; i++)
            {
                //var defenders = defenderSquat[i].GetComponentsInChildren<Defender>();
                var defenders = defenderSquads[i].GetComponentsInChildren<Defender>();
                for (int j = 0; j < defenders.Length; j++)
                {
                    defenders[j].gameObject.SetActive(false);
                    _units.Remove(defenders[j]);
                }
            }
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