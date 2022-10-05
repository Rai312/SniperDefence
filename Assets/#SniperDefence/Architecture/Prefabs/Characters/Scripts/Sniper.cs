using UnityEngine;

public class Sniper : MonoBehaviour, IShotable
{
  [SerializeField] private OpticalSight _opticalSight;

  private void OnEnable()
  {
    _opticalSight.SightIsReleased += Shoot;
  }

  private void OnDisable()
  {
    _opticalSight.SightIsReleased -= Shoot;
  }

  public void Shoot()
  {
  }
}

public interface IShotable
{
  void Shoot();
}