using UnityEngine;

public class PlayState : IGameState
{
    private readonly UI _uI;
    private readonly Spawner _spawner;
    private readonly TeamEnemy _teamEnemy;
    private readonly TeamDefender _teamDefender;
    private readonly Battle _battle;

    public PlayState(UI uI, Spawner spawner, TeamEnemy teamEnemy, TeamDefender teamDefender, Battle battle)
    {
        _uI = uI;
        _spawner = spawner;
        _teamEnemy = teamEnemy;
        _teamDefender = teamDefender;
        _battle = battle;
    }

    public void Enter()
    {
        //Debug.Log("PlayState - Enter");
        _spawner.Enable();
        _uI.PlayMenu.Show();

        _spawner.Spawned += OnSpawned;
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        //Debug.Log("PlayState - Exit");
        _spawner.Spawned -= OnSpawned;
        _spawner.Disable();
        _battle.InitializeDefenders();
    }


    private void OnSpawned(Defender defender)
    {
        defender.Initialize(_teamEnemy.Targets);
        _teamDefender.AddSpawned(defender);

    }
}
