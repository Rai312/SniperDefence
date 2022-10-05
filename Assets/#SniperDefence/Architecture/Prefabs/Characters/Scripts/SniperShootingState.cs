using UnityEngine;

public class SniperShootingState : IGameState
{
  private readonly UI _uI;
  private readonly CameraController _cameraController;
  private readonly Sniper _sniper;
  private readonly Spawner _spawner;

  public SniperShootingState(UI uI, CameraController cameraController, Sniper sniper, Spawner spawner)
  {
    _uI = uI;
    _cameraController = cameraController;
    _sniper = sniper;
    _spawner = spawner;
  }

  private void OnEnable()
  {
    _cameraController.PlayableDirectorFinished += Enable;
  }

  private void OnDisable()
  {
    _cameraController.PlayableDirectorFinished -= Enable;
  }

  public void Enter()
  {
    OnEnable();
    _spawner.enabled = false;
    _uI.SniperMenu.Show();
    Debug.Log("Enter - SniperShootingState");
    _cameraController.ActivateShowSniperRoutine();
  }

  private void Enable()
  {
    _cameraController.CameraRotator.enabled = true;
    _uI.SniperMenu.OpticalSight.enabled = true;
  }
  

  public void Exit()
  {
    _uI.SniperMenu.Hide();
    Debug.Log("Enter - SniperShooter");
    OnDisable();
  }
}