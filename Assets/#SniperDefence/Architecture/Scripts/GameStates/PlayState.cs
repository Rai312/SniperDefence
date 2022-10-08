using UnityEngine;

public class PlayState : IGameState
{
  private readonly UI _uI;
  private readonly PlaceHolder _placeHolder;
  //private readonly TeamEnemy _teamEnemy;
  //private readonly TeamDefender _teamDefender;
  private readonly Battle _battle;

  public PlayState(UI uI, PlaceHolder placeHolder, Battle battle)
  {
    _uI = uI;
    _placeHolder = placeHolder;
    //_teamEnemy = teamEnemy;
    //_teamDefender = teamDefender;
    _battle = battle;
  }

  public void Enter()
  {
    //Debug.Log("PlayState - Enter");
    _placeHolder.Enable();
    _uI.PlayMenu.Show();

    _placeHolder.Spawned += OnSpawned;
  }

  public void Exit()
  {
    _uI.PlayMenu.Hide();
    //Debug.Log("PlayState - Exit");
    _placeHolder.Spawned -= OnSpawned;
    _placeHolder.Disable();
    _battle.InitializeDefenders();
  }
  
  private void OnSpawned(DefenderSquat defenderSquat)
  {
    var defenders = defenderSquat.GetComponentsInChildren<Defender>();

    for (int i = 0; i < defenders.Length; i++)
    {
      //defenders[i].Initialize(_teamEnemy.Units);
      defenders[i].Initialize(_battle.TeamEnemy.Units);
    }
    
    _battle.TeamDefender.AddSpawned(defenderSquat);
    // _teamDefender.AddSpawned(defender);
  }
}