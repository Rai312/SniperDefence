using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    [SerializeField] private TeamContainer _teamContainer;

    public IReadOnlyList<Unit> Units => _units;
    public TeamContainer TeamContainer => _teamContainer;
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