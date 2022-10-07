using UnityEngine;

public class Grid : MonoBehaviour
{
  private DefenderSquat _defenderSquat;
  private bool _isBusy = false;

  public bool IsBusy => _isBusy;

  public void MakeIsBusy() => _isBusy = true;

  public void AddUnits(DefenderSquat defenderSquat)
  {
    _defenderSquat = defenderSquat;
  }
}