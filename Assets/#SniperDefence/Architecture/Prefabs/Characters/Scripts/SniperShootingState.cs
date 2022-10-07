using UnityEngine;

public class SniperShootingState : IGameState
{
  private readonly UI _uI;
  private readonly CameraController _cameraController;
  private readonly Sniper _sniper;
  private readonly PlaceHolder _placeHolder;
  private readonly TeamEnemy _teamEnemy;
  private readonly TeamDefender _teamDefender;

  public SniperShootingState(UI uI, CameraController cameraController,
    Sniper sniper, PlaceHolder placeHolder, TeamEnemy teamEnemy,
    TeamDefender teamDefender)
  {
    _uI = uI;
    _cameraController = cameraController;
    _sniper = sniper;
    _placeHolder = placeHolder;
    _teamEnemy = teamEnemy;
    _teamDefender = teamDefender;
  }

  public void Enter()
  {
    //Debug.Log("ShootingState - Enter");
    for (int i = 0; i < _teamEnemy.Units.Count; i++)
    {
      _teamEnemy.Units[i].SetWaiting();
    }

    for (int i = 0; i < _teamDefender.Units.Count; i++)
    {
      _teamDefender.Units[i].SetWaiting();
    }

    _cameraController.PlayableDirectorFinished += Enable;

    _placeHolder.enabled = false;
    _uI.SniperMenu.Show();

    _cameraController.ActivateShowSniperRoutine();
  }

  public void Exit()
  {
    _uI.SniperMenu.Hide();
    //Debug.Log("ShootingState - Exit");

    _cameraController.PlayableDirectorFinished -= Enable;
  }

  private void Enable()
  {
    _cameraController.CameraRotator.enabled = true;
    _uI.SniperMenu.OpticalSight.enabled = true;
  }
}