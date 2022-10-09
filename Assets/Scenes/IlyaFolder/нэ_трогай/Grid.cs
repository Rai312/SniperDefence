using UnityEngine;

public class Grid : MonoBehaviour
{
  [field: SerializeField] public int IndexNumber { get; private set; }

  private DefenderSquad _defenderSquad;
  private bool _isBusy = false;
  private bool _isActive = false;

  public bool IsActive => _isActive;
  public bool IsBusy => _isBusy;
  public DefenderSquad DefenderSquad => _defenderSquad;

  public void MakeIsBusy() => _isBusy = true;
  public void MakeIsFree() => _isBusy = false;
  public void MakeIsActive() => _isActive = true;
  public void MakeIsInactive() => _isActive = false;


  public void AddDefenderSquad(DefenderSquad defenderSquad) => _defenderSquad = defenderSquad;
  public void DeleteUnits() => _defenderSquad = null;
}