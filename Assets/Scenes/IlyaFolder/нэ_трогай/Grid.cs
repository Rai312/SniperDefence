using UnityEngine;

public class Grid : MonoBehaviour
{
  private DefenderSquad _defenderSquad;
  private bool _isBusy = false;

  public bool IsBusy => _isBusy;

  public void MakeIsBusy() => _isBusy = true;

  public void AddUnits(DefenderSquad defenderSquad) => _defenderSquad = defenderSquad;
}