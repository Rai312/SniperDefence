using System;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
  [SerializeField] private List<Grid> _grids = new List<Grid>();
  [SerializeField] private BuyButton[] _buyButtons;

  public event Action<DefenderSquad> Spawned;
  
  private void OnEnable()
  {
    for (int i = 0; i < _buyButtons.Length; i++)
    {
      _buyButtons[i].ButtonClick += SpawnDefender;
    }
  }

  private void OnDisable()
  {
    for (int i = 0; i < _buyButtons.Length; i++)
    {
      _buyButtons[i].ButtonClick -= SpawnDefender;
    }
  }
  
  public void Enable()
  {
    enabled = true;
  }

  public void Disable()
  {
    enabled = false;
  }

  private void SpawnDefender(DefenderSquad defenderSquad)
  {
    int count = 0;

    for (int i = 0; i < _grids.Count; i++)
    {
      if (_grids[i].IsBusy == false)
      {
        DefenderSquad newDefenderSquad = Instantiate(defenderSquad, _grids[i].transform.position, Quaternion.identity, null);
                Debug.Log("SpawnDefender");
        Spawned?.Invoke(newDefenderSquad); 
        _grids[i].AddDefenderSquad(newDefenderSquad);
        _grids[i].MakeIsBusy();
        count++;
      }

      if (count == 1)
        break;
    }
  }
}