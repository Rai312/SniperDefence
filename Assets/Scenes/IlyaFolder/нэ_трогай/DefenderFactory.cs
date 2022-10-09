using System.Collections.Generic;
using NativeSerializableDictionary;
using UnityEngine;

public class DefenderFactory : MonoBehaviour
{
  [SerializeField] private SerializableDictionary<int, DefenderSquad> _shootingMap = new Dictionary<int, DefenderSquad>();
  [SerializeField] private SerializableDictionary<int, DefenderSquad> _fighterMap = new Dictionary<int, DefenderSquad>();
  
  public DefenderSquad GetDefenderSquad(int key, DefenderType type)
  {
    if (type == DefenderType.Fighter)
      return _fighterMap[key].Value;
    else if (type == DefenderType.Shooting)
      return _shootingMap[key].Value;
    else
      return null;
  }
}