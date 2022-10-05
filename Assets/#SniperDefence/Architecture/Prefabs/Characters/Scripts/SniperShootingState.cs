using UnityEngine;

public class SniperShootingState : IGameState
{
  private readonly UI _uI;
  private readonly CameraController _cameraController;
  private readonly Sniper _sniper;

  public SniperShootingState(UI uI, CameraController cameraController, Sniper sniper)
  {
    _uI = uI;
    _cameraController = cameraController;
    _sniper = sniper;
  }

  private void OnEnable()
  {
    _cameraController.PlayableDirectorFinished += Show;
  }

  private void OnDisable()
  {
    _cameraController.PlayableDirectorFinished -= Show;
  }

  public void Enter()
  {
    OnEnable();
    _cameraController.ActivateShowSniperRoutine();
  }

  private void Show()
  {
     _cameraController.CameraRotator.gameObject.SetActive(true);
     _uI.SniperMenu.OpticalSight.gameObject.SetActive(true);
  }
  

  public void Exit()
  {
    OnDisable();
  }
}