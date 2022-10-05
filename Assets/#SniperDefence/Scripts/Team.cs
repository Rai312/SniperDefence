using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;

    public IReadOnlyList<Unit> Units => _units;

    public void AddSpawned(Unit unit)
    {
        Debug.Log("AddSpawned");
        _units.Add(unit);
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
