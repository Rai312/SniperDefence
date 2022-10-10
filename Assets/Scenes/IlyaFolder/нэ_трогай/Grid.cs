using UnityEngine;

public class Grid : MonoBehaviour
{
  private ParticleSystem _mergeParticleSystem;
  private DefenderSquad _defenderSquad;
  private SpriteRenderer _spriteRenderer;
  private bool _isBusy = false;
  private bool _isActive = false;

  public bool IsActive => _isActive;
  public bool IsBusy => _isBusy;
  public DefenderSquad DefenderSquad => _defenderSquad;

  private void Awake()
  {
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _mergeParticleSystem = GetComponentInChildren<ParticleSystem>();
  }

  public void ActivateMergeParticle() => _mergeParticleSystem.Play();
    
  public void MakeIsBusy() => _isBusy = true;
  
  public void MakeIsFree() => _isBusy = false;

  public void MakeIsActive() => _isActive = true;
  
  public void MakeIsInactive() => _isActive = false;

  public void ChangeColor(Color color) => _spriteRenderer.color = color;
  
  public void AddDefenderSquad(DefenderSquad defenderSquad) => _defenderSquad = defenderSquad;
  
  public void DeleteUnits() => _defenderSquad = null;
}