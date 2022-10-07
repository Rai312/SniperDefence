using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
    [SerializeField] private List<Unit> _targets;

    public IReadOnlyList<Target> Targets => _targets;

    public void AddSpawned(Unit unit)
    {
        //Debug.Log("AddSpawned");
        _targets.Add(unit);
    }

    public bool CheckLose()
    {
        foreach (var unit in _targets)
        {
            if (unit.IsAlive)
                return false;
        }

        return true;
    }
}
