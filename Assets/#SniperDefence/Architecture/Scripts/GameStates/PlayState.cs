using UnityEngine;

public class PlayState : IGameState
{
    private readonly UI _uI;
    private readonly PlaceHolder _placeHolder;
    private readonly Battle _battle;

    public PlayState(UI uI, PlaceHolder placeHolder, Battle battle)
    {
        _uI = uI;
        _placeHolder = placeHolder;
        _battle = battle;
    }

    public void Enter()
    {
        //Debug.Log("PlayState - Enter");
        _placeHolder.Enable();
        _uI.PlayMenu.Show();

        _placeHolder.Spawned += OnSpawned;
        _battle.TeamDefender.DragAndDropSystem.Merged += OnMerged;
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        //Debug.Log("PlayState - Exit");
        _placeHolder.Spawned -= OnSpawned;
        _battle.TeamDefender.DragAndDropSystem.Merged -= OnMerged;
        _placeHolder.Disable();
        _battle.InitializeDefenders();
        _battle.TeamDefender.DragAndDropSystem.gameObject.SetActive(false);
        _placeHolder.gameObject.SetActive(false);
    }

    private void OnSpawned(DefenderSquad defenderSquad)
    {
        Debug.Log("OnMerged");
        var defenders = defenderSquad.GetComponentsInChildren<Defender>();

        for (int i = 0; i < defenders.Length; i++)
        {
            defenders[i].Initialize(_battle.TeamEnemy.Units);
        }

        _battle.TeamDefender.AddSpawned(defenderSquad);
    }

    private void OnMerged(DefenderSquad defenderSquad1, DefenderSquad defenderSquad2, DefenderSquad defenderSquad3)
    {
        OnSpawned(defenderSquad1);
        //Debug.Log("OnMerged");

        DefenderSquad[] defenders = { defenderSquad2, defenderSquad3 };

        _battle.TeamDefender.RemoveDefendersMerge(defenders);
    }
}