using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
  [SerializeField] private List<Unit> _units;

  public IReadOnlyList<Unit> Units => _units;

  /*  public void AddSpawned(Unit unit)
    {
        //Debug.Log("AddSpawned");
        _units.Add(unit);
    }
*/
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