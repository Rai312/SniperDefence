using UnityEngine;

public class SniperShootingState : IGameState
{
  private readonly UI _uI;
  private readonly CameraController _cameraController;
  private readonly Sniper _sniper;
  private readonly Spawner _spawner;
  private readonly TeamEnemy _teamEnemy;
  private readonly TeamDefender _teamDefender;

  public SniperShootingState(UI uI, CameraController cameraController,
    Sniper sniper, Spawner spawner, TeamEnemy teamEnemy,
    TeamDefender teamDefender)
  {
    _uI = uI;
    _cameraController = cameraController;
    _sniper = sniper;
    _spawner = spawner;
    _teamEnemy = teamEnemy;
    _teamDefender = teamDefender;
  }

  public void Enter()
  {
    //Debug.Log("ShootingState - Enter");
    for (int i = 0; i < _teamEnemy.Targets.Count; i++)
    {
      _teamEnemy.Targets[i].SetWaiting();
    }

    for (int i = 0; i < _teamDefender.Targets.Count; i++)
    {
      _teamDefender.Targets[i].SetWaiting();
    }

    _cameraController.PlayableDirectorFinished += Enable;

    _spawner.enabled = false;
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