using System.Collections.Generic;
using BuildingBlocks.DataTypes;
using UnityEngine;

public class DefenderFactory : MonoBehaviour
{
  [SerializeField] private InspectableDictionary<int, DefenderSquad> _shootingMap = new Dictionary<int, DefenderSquad>();
  [SerializeField] private InspectableDictionary<int, DefenderSquad> _fighterMap = new Dictionary<int, DefenderSquad>();

  public DefenderSquad GetDefenderSquad(int key, DefenderType type)
  {
      if (type == DefenderType.Fighter && _fighterMap.TryGetValue(key, out DefenderSquad fighterSquad))
      return fighterSquad;
    else if (type == DefenderType.Shooting && _shootingMap.TryGetValue(key, out DefenderSquad shooterSquad))
      return shooterSquad;
    else
      return null;
  }
}